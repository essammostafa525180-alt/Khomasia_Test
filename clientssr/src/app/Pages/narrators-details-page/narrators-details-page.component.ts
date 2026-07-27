import { Component, Inject, OnInit } from '@angular/core';
import { HadithService } from '../../Services/hadith.service';
import { MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { ApiResponse } from '../../Model/BaseModel/api-response';
import { EmptyValuePipe } from '../../Pipe/empty-value.pipe';
import { NarratorDetailsResponse } from '../../Model/Narrators/narrator-details-response';

@Component({
  selector: 'app-narrators-details-page',
  imports: [EmptyValuePipe, MatDialogModule],
  templateUrl: './narrators-details-page.component.html',
  styleUrl: './narrators-details-page.component.css'
})
export class NarratorsDetailsPageComponent implements OnInit {
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _service: HadithService
  ) {
  }
  ngOnInit(): void {
    this.GetNarratorDetails();
  }

  NarratorDetails: NarratorDetailsResponse = {} as NarratorDetailsResponse;
  GetNarratorDetails() {
    this._service.getNarratorDetails(this.data.narratorId).subscribe({
      next: (response: ApiResponse<NarratorDetailsResponse>) => {
        this.NarratorDetails = response.data;
      },
    });
  }

  activeTab = 'general';


  tabs = [
    { id: 'sifat', title: 'صفة الصفوة' },
    { id: 'siyar', title: 'سير إعلام النبلاء' },
    { id: 'tahzeeb', title: 'سيرته في التهذيب' },
    { id: 'students', title: 'التلاميذ' },
    { id: 'sheikhs', title: 'الشيوخ' },
    { id: 'jarh', title: 'الجرح والعدالة' },
    { id: 'general', title: 'تعريف عام', icon: 'fas fa-star' },
  ];


  switchTab(tabId: string) {
    this.activeTab = tabId;
  }
}
