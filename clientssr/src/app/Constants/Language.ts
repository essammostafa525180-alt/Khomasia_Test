export enum Language {
  // Arabic = 0,
  English = 1,
  French = 2,
  Urdu = 3,
  Indonesian = 4,
  Turkish = 5,
}

export const LanguageLabels: { [key in Language]: string } = {
  // [Language.Arabic]: 'العربية',
  [Language.English]: 'الإنجليزية',
  [Language.French]: 'الفرنسية',
  [Language.Urdu]: 'الأردية',
  [Language.Indonesian]: 'الإندونيسية',
  [Language.Turkish]: 'التركية',
};
