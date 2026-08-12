import { ExportButton } from "../Model/ExportButton";

export const exportTypeConst = {
  PDF: 'PDF',
  CSV: 'CSV',
  PRINT: 'Print',
  COPY: 'Copy',
} as const;


export const EXPORT_BUTTONS: ExportButton[] = [
  {
    type: exportTypeConst.PDF,
    icon: 'picture_as_pdf',
  },
  {
    type: exportTypeConst.CSV,
    icon: 'description',
  },
  {
    type: exportTypeConst.PRINT,
    icon: 'print',
  },
  {
    type: exportTypeConst.COPY,
    icon: 'content_copy',
  },
];