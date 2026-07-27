export interface HadithListResponse {
  id: number;
  hadithWithSign: string ;
  hadithWithNoSign: string ;
  matn: string ;
  isAvailable: boolean;
  audioUrl: string | null;
  babId: number;
}