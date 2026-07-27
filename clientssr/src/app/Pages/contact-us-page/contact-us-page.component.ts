import { Component } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';

import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';

import { HadithService } from '../../Services/hadith.service';
import { ContactMessage } from '../../Model/ContactUs/contact-message';

import { MatDialogModule } from '@angular/material/dialog';

@Component({
    selector: 'app-contact-us-page',
    imports: [ReactiveFormsModule, CommonModule, MatDialogModule],
    templateUrl: './contact-us-page.component.html',
    styleUrl: './contact-us-page.component.css'
})
export class ContactUsPageComponent {
  contactForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private toastr: ToastrService,
    private _hadithService: HadithService,
    private dialogRef: MatDialogRef<ContactUsPageComponent>
  ) {
    this.contactForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      subject: ['', Validators.required],
      message: ['', Validators.required]
    });
  }

  onSubmit() {
    const controls = this.contactForm.controls;

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

    const contactData: ContactMessage = {
      name: this.contactForm.value.name,
      email: this.contactForm.value.email,
      subject: this.contactForm.value.subject,
      message: this.contactForm.value.message,
      pageUrl: null,
      isRead: false,
      isNote: false
    };



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
