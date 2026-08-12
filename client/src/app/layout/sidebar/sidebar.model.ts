export interface MenuItem {
  label: string;
  icon?: string;
  link?: string;
  children?: MenuItem[];
  expanded?: boolean;
}