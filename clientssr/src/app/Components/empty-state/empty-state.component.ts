import { Component, Input } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Location } from '@angular/common';

@Component({
    selector: 'app-empty-state',
    imports: [RouterLink],
    templateUrl: './empty-state.component.html',
    styleUrl: './empty-state.component.css'
})
export class EmptyStateComponent {
    /** أيقونة FontAwesome للعرض في الحالة الفارغة */
    @Input() icon: string = 'fas fa-search';

    /** العنوان الرئيسي للرسالة */
    @Input() title: string = 'عذراً، لا توجد بيانات';

    /** الوصف التوضيحي */
    @Input() message: string = '';

    /** إظهار زر العودة للخلف */
    @Input() showBackButton: boolean = true;

    /** إظهار زر الرئيسية */
    @Input() showHomeButton: boolean = true;

    constructor(private location: Location) { }

    goBack() {
        this.location.back();
    }
}
