import {
    Directive,
    ElementRef,
    HostListener,
    Input,
    OnDestroy,
    OnInit,
    ViewContainerRef
} from '@angular/core';
import {
    Overlay,
    OverlayPositionBuilder,
    OverlayRef,
    ScrollStrategyOptions
} from '@angular/cdk/overlay';
import { ComponentPortal } from '@angular/cdk/portal';
import { TooltipComponent } from '../src/app/Components/tooltip/tooltip.component';

@Directive({
    selector: '[customTooltip]',
    standalone: true
})
export class CustomTooltipDirective implements OnInit, OnDestroy {
    @Input('customTooltip') text: string = '';
    private overlayRef: OverlayRef | null = null;

    constructor(
        private overlay: Overlay,
        private overlayPositionBuilder: OverlayPositionBuilder,
        private elementRef: ElementRef,
        private viewContainerRef: ViewContainerRef,
        private scrollStrategyOptions: ScrollStrategyOptions
    ) { }

    ngOnInit(): void { }

    @HostListener('mouseenter')
    show() {
        if (this.overlayRef) return;

        const positionStrategy = this.overlayPositionBuilder
            .flexibleConnectedTo(this.elementRef)
            .withPositions([
                {
                    originX: 'center',
                    originY: 'top',
                    overlayX: 'center',
                    overlayY: 'bottom',
                    offsetY: -8 // Distances to avoid overlap
                },
                {
                    originX: 'center',
                    originY: 'bottom',
                    overlayX: 'center',
                    overlayY: 'top',
                    offsetY: 8 // Fallback below if no room above
                }
            ]);

        const scrollStrategy = this.scrollStrategyOptions.reposition();

        this.overlayRef = this.overlay.create({
            positionStrategy,
            scrollStrategy,
            hasBackdrop: false,
            panelClass: 'custom-tooltip-overlay-pane'
        });

        const tooltipPortal = new ComponentPortal(TooltipComponent, this.viewContainerRef);
        const tooltipRef = this.overlayRef.attach(tooltipPortal);
        tooltipRef.instance.text = this.text;
    }

    @HostListener('mouseleave')
    hide() {
        this.close();
    }

    ngOnDestroy(): void {
        this.close();
    }

    private close() {
        if (this.overlayRef) {
            this.overlayRef.dispose();
            this.overlayRef = null;
        }
    }
}
