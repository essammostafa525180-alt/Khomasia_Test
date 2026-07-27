import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { ContactMessage } from '../../Model/ContactUs/contact-message';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { HadithService } from '../../Services/hadith.service';
import { ContactUsPageComponent } from '../contact-us-page/contact-us-page.component';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { HadithListResponse } from '../../Model/Hadith/hadith-list-response';
import { HadithFormatterPipe } from '../../Pipe/hadith-formatter.pipe';
import { MatDialogModule } from '@angular/material/dialog';
import { CommonModule } from '@angular/common';

@Component({
    selector: 'app-proposal-page',
    imports: [ReactiveFormsModule, CommonModule, MatDialogModule],
    templateUrl: './proposal-page.component.html',
    styleUrl: './proposal-page.component.css'
})
export class ProposalPageComponent {
  // --- State Variables ---
  contactForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private toastr: ToastrService,
    private _hadithService: HadithService,
    private dialogRef: MatDialogRef<ContactUsPageComponent>,
    @Inject(MAT_DIALOG_DATA) public data: HadithListResponse
  ) {
    // تجهيز رسالة العنوان التلقائية بناءً على الحديث المختار
    const words = this.data.hadithWithSign.split(' ');
    const first10Words = words.slice(0, 10).join(' ');
    const message = ' يوجد مقترح في  معرف حديث رقم  ' + '(' + this.data.id + ')' + ' نص الحديث  ' + ' " ' + first10Words + ' ... ' + ' " ';

    // بناء نموذج الإدخال (Form)
    this.contactForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      subject: [message, Validators.required],
      message: ['', Validators.required]
    });
  }

  // --- Methods ---

  /** إرسال طلب الاقتراح للخدمة مع التحقق من صحة البيانات */
  onSubmit() {
    const controls = this.contactForm.controls;

    // التحقق من صحة المدخلات وإظهار تنبيهات مخصصة
    if (this.contactForm.invalid) {
      if (controls['name'].invalid) {
        this.toastr.warning('يرجى إدخال الاسم بالكامل', 'تنبيه');
      } else if (controls['email'].errors?.['required']) {
        this.toastr.warning('يرجى إدخال البريد الإلكتروني', 'تنبيه');
      } else if (controls['email'].errors?.['email']) {
        this.toastr.warning('صيغة البريد الإلكتروني غير صحيحة', 'تنبيه');
      } else if (controls['subject'].invalid) {
        this.toastr.warning('يرجى إدخال عنوان الرسالة', 'تنبيه');
      } else if (controls['message'].invalid) {
        this.toastr.warning('يرجى كتابة نص الرسالة', 'تنبيه');
      }
      return;
    }

    // تجهيز البيانات لإرسالها
    const contactData: ContactMessage = {
      name: this.contactForm.value.name,
      email: this.contactForm.value.email,
      subject: this.contactForm.value.subject,
      message: this.contactForm.value.message,
      pageUrl: window.location.href,
      isRead: false,
      isNote: false
    };

    // استدعاء الخدمة للإرسال
    this._hadithService.CreateProposal(contactData).subscribe({
      next: (response) => {
        this.toastr.success('تم إرسال رسالتك بنجاح', 'تم الإرسال', {
          timeOut: 5000,
        });
        this.contactForm.reset();
        this.dialogRef.close();
      },
      error: (error) => {
        this.toastr.error('حدث خطأ أثناء إرسال الرسالة', 'خطأ');
      }
    });
  }
}
