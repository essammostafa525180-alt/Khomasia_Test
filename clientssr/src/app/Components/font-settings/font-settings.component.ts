import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTooltipModule } from '@angular/material/tooltip';

@Component({
    selector: 'app-font-settings',
    imports: [CommonModule, MatTooltipModule],
    templateUrl: './font-settings.component.html',
    styleUrls: ['./font-settings.component.css']
})
export class FontSettingsComponent implements OnInit {
    isOpen = false;

    fonts = [
        { name: 'خط الأميري', icon: 'fa-pen-nib', family: '"Amiri", serif' },
        { name: 'خط كايرو', icon: 'fa-laptop-code', family: '"Cairo", sans-serif' },
        { name: 'خط الكوفي', icon: 'fa-mosque', family: '"Reem Kufi", sans-serif' },
        { name: 'خط لاليزار', icon: 'fa-heading', family: '"Lalezar", cursive' },
        { name: 'خط لطيف', icon: 'fa-feather-alt', family: '"Lateef", cursive' }
    ];
    ngOnInit() {
        if (typeof window !== 'undefined') {
            const savedFont = localStorage.getItem('app-font');
            if (savedFont) {
                this.changeFont(savedFont, false);
            }
        }
    }

    toggleSettings() {
        this.isOpen = !this.isOpen;
    }

    changeFont(family: string, save: boolean = true) {
        document.documentElement.style.setProperty('--font-main', family);
        if (save && typeof window !== 'undefined') {
            localStorage.setItem('app-font', family);
        }
    }

    resetFont() {
        const defaultFont = this.fonts[0].family;
        this.changeFont(defaultFont, true);
        this.isOpen = false;
    }

    closeSettings() {
        this.isOpen = false;
    }
}
