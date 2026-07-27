import { Component, HostListener, Input, ElementRef, ViewChild, OnDestroy, Inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { HadithListResponse } from '../../Model/Hadith/hadith-list-response';
import { HadithFormatterPipe } from '../../Pipe/hadith-formatter.pipe';
import { HadithService } from '../../Services/hadith.service';
import { ApiResponse } from '../../Model/BaseModel/api-response';
import { HadithTranslation } from '../../Model/Hadith/hadith-translation';
import { Language, LanguageLabels } from '../../Constants/Language';
import { WordsLimitPipe } from '../../Pipe/words-limit.pipe';
import { HadithSharhResponse } from '../../Model/Sharh/hadith-sharh-response';
import { RouterLink } from "@angular/router";
import { SharedService } from '../../Services/shared.service';
import { MatTooltipModule } from '@angular/material/tooltip';

@Component({
    selector: 'app-hadith-card',
    imports: [MatDialogModule, HadithFormatterPipe, WordsLimitPipe, RouterLink, MatTooltipModule],
    templateUrl: './hadith-card.component.html',
    styleUrl: './hadith-card.component.css'
})
export class HadithCardComponent {
  @Input({ required: true }) hadithContant!: HadithListResponse;
  @Input({ required: true }) babId!: number;
  @ViewChild('audioPlayer') audioPlayer!: ElementRef<HTMLAudioElement>;

  Language = Language;
  LanguageLabels = LanguageLabels;
  languages = Object.values(Language).filter((v) => typeof v === 'number') as Language[];

  isPlaying = false;
  currentTime = 0;
  duration = 0;
  volume = 1;
  isMuted = false;
  previousVolume = 1;
  selectedLanguage: Language | null = null;
  showText: 'text' | 'matn' | '' = 'text';
  showTashkil: boolean = true;
  hadithTranslationContent: string | null = null;
  sharhMap = new Map<number, HadithSharhResponse[]>();
  audioBlobUrl: string | null = null;

  constructor(
    public dialog: MatDialog,
    private _service: HadithService,
    private shared: SharedService,
    @Inject(PLATFORM_ID) private platformId: Object
  ) { }

  ngOnDestroy() {
    if (isPlatformBrowser(this.platformId) && this.audioBlobUrl) {
      URL.revokeObjectURL(this.audioBlobUrl);
    }
  }


  togglePlay() {
    if (!isPlatformBrowser(this.platformId)) return;

    const audio = this.audioPlayer.nativeElement;

    if (this.isPlaying) {
      audio.pause();
      this.isPlaying = false;
      return;
    }

    if (this.audioBlobUrl) {
      audio.play();
      this.isPlaying = true;
      return;
    }

    if (this.hadithContant.audioUrl) {
      this._service.getAudio(this.hadithContant.audioUrl).subscribe(res => {
        if (res.isSuccess && res.data) {
          this.audioBlobUrl = URL.createObjectURL(res.data);
          audio.src = this.audioBlobUrl;
          audio.load();
          audio.play();
          this.isPlaying = true;
        } else {
          this.shared.triggerToast('فشل تحميل الملف الصوتي', 'error');
        }
      });
    }
  }

  toggleMute() {
    if (!isPlatformBrowser(this.platformId)) return;
    const audio = this.audioPlayer.nativeElement;
    if (this.isMuted) {
      audio.volume = this.previousVolume;
      this.volume = this.previousVolume;
    } else {
      this.previousVolume = this.volume;
      audio.volume = 0;
      this.volume = 0;
    }
    this.isMuted = !this.isMuted;
  }

  onVolumeChange(event: any) {
    if (!isPlatformBrowser(this.platformId)) return;
    const audio = this.audioPlayer.nativeElement;
    this.volume = event.target.value;
    audio.volume = this.volume;
    this.isMuted = this.volume == 0;
  }

  onTimeUpdate() {
    if (!isPlatformBrowser(this.platformId)) return;
    const audio = this.audioPlayer.nativeElement;
    this.currentTime = audio.currentTime;
  }

  onLoadedMetadata() {
    if (!isPlatformBrowser(this.platformId)) return;
    const audio = this.audioPlayer.nativeElement;
    this.duration = audio.duration;
  }

  onSeek(event: any) {
    if (!isPlatformBrowser(this.platformId)) return;
    const audio = this.audioPlayer.nativeElement;
    audio.currentTime = event.target.value;
  }

  formatTime(time: number): string {
    if (isNaN(time)) return '00:00';
    const minutes = Math.floor(time / 60);
    const seconds = Math.floor(time % 60);
    return `${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`;
  }

  getHadithTranslation(lang: Language, selId: number) {
    this.selectedLanguage = lang;
    this.hadithTranslationContent = null;

    this._service.getHadithByLang(lang, selId).subscribe({
      next: (res: ApiResponse<HadithTranslation>) => {
        if (res.isSuccess && res.data) {
          this.hadithTranslationContent = res.data.content;
          this.showText = '';
        } else {
          this.showText = '';
          this.hadithTranslationContent = null;
        }
      },
    });
  }

  getBookSharhByHadithId(selId: number) {
    this._service.getBookSharhByHadithId(selId).subscribe({
      next: (res: ApiResponse<HadithSharhResponse[]>) => {
        if (res.isSuccess && res.data) {
          this.sharhMap.set(selId, res.data);
        }
      },
    });
  }

  
  selectTab(tab: 'text' | 'matn') {
    this.showText = tab;
    this.selectedLanguage = null;
    this.hadithTranslationContent = null;
  }

  toggleTashkil() {
    this.showTashkil = !this.showTashkil;
  }

  async sharhDetails(sharh: HadithSharhResponse) {
    const { SharhHadithPageComponent } = await import('../../Pages/sharh-hadith-page/sharh-hadith-page.component');
    this.dialog.open(SharhHadithPageComponent, {
      width: '90vw',
      maxWidth: '800px',
      height: 'auto',
      panelClass: 'rawi-dialog',
      data: { data: sharh },
    });
  }

  async CreateProposal(hadithInfo: HadithListResponse) {
    const { ProposalPageComponent } = await import('../../Pages/proposal-page/proposal-page.component');
    this.dialog.open(ProposalPageComponent, {
      width: '90vw',
      maxWidth: '800px',
      height: 'auto',
      data: hadithInfo,
      panelClass: 'contact-dialog',
    });
  }

  /** نسخ نص الحديث إلى الحافظة بشكل نظيف (بدون أكواد داخلية) وبجميع اللغات */
  copyToClipboard() {
    let sourceText = '';

    // التحقق أولاً إذا كان هناك ترجمة معروضة حالياً
    if (this.selectedLanguage && this.hadithTranslationContent) {
      // إزالة وسوم HTML من الترجمة قبل النسخ
      sourceText = this.hadithTranslationContent.replace(/<[^>]*>/g, '') || '';
    }
    // إذا كنت في تبويب "المتن فقط" (العربية)
    else if (this.showText === 'matn') {
      sourceText = this.hadithContant.matn || '';
    }
    // الحالة الافتراضية (النص الكامل بالعربية)
    else {
      sourceText = (this.showTashkil ? this.hadithContant.hadithWithSign : this.hadithContant.hadithWithNoSign) || '';
    }

    // تنظيف النص العربي من أكواد الرواة {R:ID:Text} وأكواد معاني الكلمات {T:Title,Text}
    const cleanText = sourceText
      .replace(/\{R:\d+:(.+?)\}/g, '$1') // استبدال {R:123:إسم} بـ "إسم"
      .replace(/\{T:.+?,(.+?)\}/g, (match, text) => text.trim()); // استبدال {T:معنى,كلمة} بـ "كلمة"

    if (isPlatformBrowser(this.platformId)) {
      navigator.clipboard.writeText(cleanText).then(() => {
        this.shared.triggerToast('تم نسخ النص بنجاح', 'success');
      });
    }
  }

  /** مشاركة رابط الحديث عبر منصات التواصل الاجتماعي */
  shareHadith() {
    this.shared.shareHadith(this.babId, this.hadithContant.id, this.hadithContant.hadithWithNoSign);
  }

  /** مشاركة الحديث على فيسبوك */
  shareOnFacebook() {
    this.shared.shareOnFacebook(this.babId, this.hadithContant.id);
  }

  /** مشاركة الحديث على منصة X */
  shareOnX() {
    this.shared.shareOnX(this.babId, this.hadithContant.id, this.hadithContant.hadithWithNoSign);
  }
}
