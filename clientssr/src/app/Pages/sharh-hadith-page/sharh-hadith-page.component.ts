import { Component, Inject, OnInit } from '@angular/core';
import { HadithSharhResponse } from '../../Model/Sharh/hadith-sharh-response';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { WordsLimitPipe } from '../../Pipe/words-limit.pipe';
import { HighlightTextPipe } from '../../Pipe/highlight-text.pipe';
import { SplitTaxtPipe } from '../../Pipe/split-taxt.pipe';
import { CommonModule } from '@angular/common';
import { HadithService } from '../../Services/hadith.service';
import { ApiResponse } from '../../Model/BaseModel/api-response';

export interface SharhDialogData {
  data?: HadithSharhResponse;
  bookId?: number | null;
  hadithId?: number;
}

@Component({
    selector: 'app-sharh-hadith-page',
    imports: [WordsLimitPipe, HighlightTextPipe, SplitTaxtPipe, CommonModule, MatDialogModule],
    templateUrl: './sharh-hadith-page.component.html',
    styleUrl: './sharh-hadith-page.component.css'
})
export class SharhHadithPageComponent implements OnInit {
  data?: HadithSharhResponse;

  constructor(
    @Inject(MAT_DIALOG_DATA) public dialogData: SharhDialogData,
    private _hadithService: HadithService,
    private dialogRef: MatDialogRef<SharhHadithPageComponent>
  ) { }

  ngOnInit(): void {
    if (this.dialogData.data && typeof this.dialogData.data !== 'number') {
      this.data = this.dialogData.data;
    } else {
      const id = this.dialogData.hadithId || (typeof this.dialogData.data === 'number' ? this.dialogData.data : null);
      if (id) {
        this.loadSharhById(this.dialogData.bookId!, id);
      }
    }
  }

  loadSharhById(bookId: number, hadithId: number) {
    this._hadithService.getHadithSharhByHadithId(bookId, hadithId).subscribe({
      next: (res: ApiResponse<HadithSharhResponse>) => {
        if (res.isSuccess && res.data) {
          this.data = res.data;
        }
      }
    });
  }
}
