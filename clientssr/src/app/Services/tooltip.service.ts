import { Injectable, Inject, PLATFORM_ID, ViewContainerRef, Renderer2, RendererFactory2, NgZone } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { Overlay, OverlayRef, OverlayPositionBuilder, ScrollStrategyOptions } from '@angular/cdk/overlay';
import { ComponentPortal } from '@angular/cdk/portal';
import { TooltipComponent } from '../Components/tooltip/tooltip.component';

@Injectable({
    providedIn: 'root'
})
export class TooltipService {
    private overlayRef: OverlayRef | null = null;
    private renderer: Renderer2;

    constructor(
        private overlay: Overlay,
        private positionBuilder: OverlayPositionBuilder,
        private scrollStrategyOptions: ScrollStrategyOptions,
        private ngZone: NgZone,
        rendererFactory: RendererFactory2,
        @Inject(PLATFORM_ID) private platformId: Object
    ) {
        this.renderer = rendererFactory.createRenderer(null, null);
    }

    /**
     * Initialize global listeners for dynamic tooltips (innerHTML)
     */
    private currentElement: HTMLElement | null = null;
    private unlisteners: Function[] = [];

    initGlobalTooltipListeners() {
        if (!isPlatformBrowser(this.platformId)) return;


        this.ngZone.runOutsideAngular(() => {
            // Mousemove is the definitive source of truth for cursor position
            document.addEventListener('mousemove', (event: MouseEvent) => {
                const target = (event.target as HTMLElement).closest('.custom-tooltip-trigger') as HTMLElement;

                if (target) {
                    // Scenario: Entered a trigger OR moved from one trigger to another
                    if (this.currentElement !== target) {
                        this.ngZone.run(() => {
                            this.currentElement = target;
                            this._openTooltip(target, target.getAttribute('data-tooltip') || '');
                        });
                    }
                } else {
                    // Scenario: Moved away from all triggers
                    if (this.currentElement) {
                        this.ngZone.run(() => {
                            this.close();
                        });
                    }
                }
            });

            // Extra security: Clear everything on scroll or escape
            window.addEventListener('scroll', () => {
                if (this.currentElement) this.ngZone.run(() => this.close());
            }, { passive: true });

            document.addEventListener('keydown', (event: KeyboardEvent) => {
                if (event.key === 'Escape' && this.currentElement) {
                    this.ngZone.run(() => this.close());
                }
            });

            // Touch support for mobile
            document.addEventListener('touchstart', (event: TouchEvent) => {
                const target = (event.target as HTMLElement).closest('.custom-tooltip-trigger') as HTMLElement;
                if (target) {
                    this.ngZone.run(() => {
                        this.currentElement = target;
                        this._openTooltip(target, target.getAttribute('data-tooltip') || '');
                    });
                } else if (this.currentElement) {
                    this.ngZone.run(() => this.close());
                }
            }, { passive: true });
        });
    }

    private _openTooltip(element: HTMLElement, text: string) {
        // Internal open: dispose previous overlay but DON'T reset currentElement
        if (this.overlayRef) {
            this.overlayRef.dispose();
            this.overlayRef = null;
        }

        const positionStrategy = this.positionBuilder
            .flexibleConnectedTo(element)
            .withPositions([
                {
                    originX: 'center', originY: 'top',
                    overlayX: 'center', overlayY: 'bottom',
                    offsetY: -12
                },
                {
                    originX: 'center', originY: 'bottom',
                    overlayX: 'center', overlayY: 'top',
                    offsetY: 12
                }
            ]);

        this.overlayRef = this.overlay.create({
            positionStrategy,
            scrollStrategy: this.scrollStrategyOptions.reposition(),
            panelClass: 'custom-tooltip-overlay-pane',
            direction: 'rtl',
            hasBackdrop: false
        });

        const tooltipPortal = new ComponentPortal(TooltipComponent);
        const tooltipRef = this.overlayRef.attach(tooltipPortal);
        tooltipRef.instance.text = text;
        tooltipRef.changeDetectorRef.detectChanges();
    }

    private close() {
        this.currentElement = null; // Permanent clear
        if (this.overlayRef) {
            this.overlayRef.dispose();
            this.overlayRef = null;
        }
    }

    ngOnDestroy() {
        // Listeners attached via addEventListener should be cleaned up ideally, 
        // but since this is a root service it lives for the app lifetime.
    }
}
