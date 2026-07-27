import { Component, OnInit } from '@angular/core';
import { HadithService } from '../../Services/hadith.service';
import { ApiResponse } from '../../Model/BaseModel/api-response';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HadithFormatterPipe } from '../../Pipe/hadith-formatter.pipe';
import { OtherBookSharhHadithResponse } from '../../Model/Sharh/other-book-sharh-hadith-content';
import { HadithListResponse } from '../../Model/Hadith/hadith-list-response';
import { ToastrService } from 'ngx-toastr';
import { SharedService } from '../../Services/shared.service';
import { SharhHadithPageComponent } from '../sharh-hadith-page/sharh-hadith-page.component';
import { MatDialog } from '@angular/material/dialog';
import { OtherSharhResolvedData } from '../../Resolvers/other-sharh-resolver';

@Component({
  selector: 'app-other-sharh-page',
  imports: [CommonModule, RouterModule, HadithFormatterPipe],
  templateUrl: './other-sharh-page.component.html',
  styleUrl: './other-sharh-page.component.css'
})
export class OtherSharhPageComponent implements OnInit {

  otherBookSharh: OtherBookSharhHadithResponse[] = [];
  selectedBookId: number | null = null;
  hadithMap = new Map<number, HadithListResponse>();
  firstHadith?: HadithListResponse;
  selectedHadith?: HadithListResponse;
  highlightTrigger = false;

  constructor(
    private _hadithService: HadithService,
    private _activatedRoute: ActivatedRoute,
    private toastr: ToastrService,
    public shared: SharedService,
    private dialog: MatDialog,
  ) { }

  ngOnInit(): void {
    const id = Number(this._activatedRoute.snapshot.paramMap.get('id'));
    const resolved: OtherSharhResolvedData = this._activatedRoute.snapshot.data['otherSharhData'];

    if (resolved) {
      this.otherBookSharh = resolved.otherBookSharh.data;
      if (resolved.hadith.data) {
        this.firstHadith = resolved.hadith.data;
        this.hadithMap.set(id, resolved.hadith.data);
      }
    } else {
      this.getOtherBookSharh(id);
      this.getHadithById(id, true);
    }
  }

  goToHadith(babId: number, hadithId: number) {
    this.shared.goToHadith(babId, hadithId);
  }

  goBack() {
    window.history.back();
  }

  getOtherBookSharh(hadithId: number) {
    this._hadithService.getOtherBookSharh(hadithId).subscribe({
      next: (res: ApiResponse<OtherBookSharhHadithResponse[]>) => {
        this.otherBookSharh = res.data;
      }
    });
  }

  getHadithById(hadithId: number, isFirst: boolean = false) {
    if (this.hadithMap.has(hadithId)) {
      const cached = this.hadithMap.get(hadithId)!;
      if (!isFirst) {
        this.selectedHadith = cached;
        this.highlightTrigger = false;
        this.shared.scrollToElement('hadith-compare-target');
        setTimeout(() => {
          this.highlightTrigger = true;
        }, 10);
      }
      return;
    }

    this._hadithService.getHadithById(hadithId).subscribe({
      next: (res: ApiResponse<HadithListResponse>) => {
        if (res.data) {
          this.hadithMap.set(hadithId, res.data);
          if (isFirst) {
            this.firstHadith = res.data;
          } else {
            this.selectedHadith = res.data;
            this.highlightTrigger = false;
            this.shared.scrollToElement('hadith-compare-target');
            setTimeout(() => {
              this.highlightTrigger = true;
            }, 10);
            this.toastr.warning('تكرار الأرقام يدل على أن هذا الحديث قد فُسّر في أكثر من كتاب', 'تنبيه', {
              timeOut: 80000
            });
          }
        }
      },
    });
  }

  selectSharh(bookId: number | null | undefined) {
    this.selectedBookId = bookId || null;
  }

  sharhDetails(hadithId: number) {
    this.dialog.open(SharhHadithPageComponent, {
      width: '90vw',
      maxWidth: '800px',
      height: 'auto',
      panelClass: 'rawi-dialog',
      data: { bookId: this.selectedBookId, hadithId: hadithId },
    });
  }
}