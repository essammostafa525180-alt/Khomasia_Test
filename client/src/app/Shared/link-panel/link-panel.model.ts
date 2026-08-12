export interface LinkPanelLink {
  label: string;
  link: string;
  icon?: string;
}

export interface LinkPanelData {
  title: string;
  icon: string;
  links: LinkPanelLink[];
}