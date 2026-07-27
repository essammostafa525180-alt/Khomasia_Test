export interface ContactMessage {
  name: string;
  email: string;
  subject: string;
  message: string;
  pageUrl: string | null;
  isRead: boolean;
  isNote: boolean;
}
