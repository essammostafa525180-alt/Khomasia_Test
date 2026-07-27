import { MatPaginatorIntl } from '@angular/material/paginator';

// دالة لتحويل الأرقام للعربي
const toArabicNumber = (n: number) => n.toString().replace(/\d/g, (d) => '٠١٢٣٤٥٦٧٨٩'[+d]);

export function getArabicPaginatorIntl(): MatPaginatorIntl {
  const intl = new MatPaginatorIntl();

  // تغيير النصوص
  intl.itemsPerPageLabel = 'عدد العناصر في الصفحة';
  intl.nextPageLabel = 'التالي';
  intl.previousPageLabel = 'السابق';
  intl.firstPageLabel = 'الصفحة الأولى';
  intl.lastPageLabel = 'الصفحة الأخيرة';

  // تغيير عرض النطاق ليظهر بالأرقام العربية
  intl.getRangeLabel = (page: number, pageSize: number, length: number) => {
    if (length === 0 || pageSize === 0) return `٠ من ${toArabicNumber(length)}`;
    const startIndex = page * pageSize;
    const endIndex = Math.min(startIndex + pageSize, length);
    return `${toArabicNumber(startIndex + 1)} - ${toArabicNumber(endIndex)} من ${toArabicNumber(length)}`;
  };

  return intl;
}
