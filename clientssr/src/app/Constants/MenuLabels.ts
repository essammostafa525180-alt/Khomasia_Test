export enum Menu {
  Home = 1,
  SunnahBooks = 2,
  Parts = 3,
  Raqaiq = 4,
  HadithSciences = 5,
  Biography = 6,
  Ahkam = 7,
  FabricatedHadith = 8,
  PopularHadith = 9,
  GharibHadith = 10,
  RefutingDoubts = 11,
  Commentaries = 12,
  Narrators = 13
}

export const MenuLabels: Record<Menu, string> = {
  [Menu.Home]: 'الرئيسية',
  [Menu.SunnahBooks]: 'كتب السنة',
  [Menu.Parts]: 'الأجزاء',
  [Menu.Raqaiq]: 'الرقائق',
  [Menu.HadithSciences]: 'علوم الحديث',
  [Menu.Biography]: 'السير',
  [Menu.Ahkam]: 'الأحكام',
  [Menu.FabricatedHadith]: 'الأحاديث الموضوعة',
  [Menu.PopularHadith]: 'أحاديث مشتهرة بين الناس',
  [Menu.GharibHadith]: 'غريب الحديث',
  [Menu.RefutingDoubts]: 'رد الشبهات',
  [Menu.Commentaries]: 'الشروح',
  [Menu.Narrators]: 'التراجم'
};
