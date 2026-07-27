import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { TakhreejContantListResponse } from '../../Model/Takhreej/takhreej-contant-list-response';
import { HadithService } from '../../Services/hadith.service';
import { ApiResponse } from '../../Model/BaseModel/api-response';
import { PagedResult } from '../../Model/BaseModel/paged-result';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { HadithFormatterPipe } from '../../Pipe/hadith-formatter.pipe';
import { MatDialog } from '@angular/material/dialog';
import { CommonModule } from '@angular/common';
import { SharedService } from '../../Services/shared.service';

@Component({
  selector: 'app-tahreej-page',
  imports: [HadithFormatterPipe, CommonModule, RouterLink],
  templateUrl: './takhreej-page.component.html',
  styleUrl: './takhreej-page.component.css'
})
export class TakhreejPageComponent implements OnInit {

  activeTab: 'complate' | 'sumary' | 'number' = 'complate';
  HadithTakhreejList: TakhreejContantListResponse[] = [];
  hadithTextToShow: TakhreejContantListResponse = {} as TakhreejContantListResponse;
  highlightTrigger = false;

  constructor(
    private _hadithService: HadithService,
    private cdr: ChangeDetectorRef,
    private route: ActivatedRoute,
    public dialog: MatDialog,
    private router: Router,
    private shared: SharedService
  ) { }

  ngOnInit(): void {
    const resolved = this.route.snapshot.data['takhreejData'];

    if (resolved) {
      this.HadithTakhreejList = resolved.data.items;
    } else {
      const id = Number(this.route.snapshot.paramMap.get('id'));
      this.getTakhreejList(id);
    }
  }

  goBack() {
    this.shared.goBack();
  }

  goToHadith(babId: number, hadithId: number) {
    this.shared.goToHadith(babId, hadithId);
  }

  getTakhreejList(hadithId: number) {
    this._hadithService.getTakhreejList(hadithId).subscribe({
      next: (res: ApiResponse<PagedResult<TakhreejContantListResponse>>) => {
        this.HadithTakhreejList = res.data.items;
      }
    });
  }

  selectTakhreej(takhreej: TakhreejContantListResponse) {
    this.hadithTextToShow = takhreej;
    this.highlightTrigger = false;
    this.cdr.detectChanges();
    setTimeout(() => {
      this.highlightTrigger = true;
      this.cdr.detectChanges();
      this.shared.scrollToElement('comparison-area');
    }, 10);
  }
}