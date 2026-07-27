import { Component, OnInit } from '@angular/core';
import { HadithService } from '../../Services/hadith.service';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { SeoService } from '../../Services/seo.service';

import { Menu } from '../../Constants/MenuLabels';
import { HadithCollection } from '../../Model/Hadith/hadith-collection';
import { BookTemplateComponent } from '../../Components/book-template/book-template.component';

@Component({
  selector: 'app-classifications-page',
  imports: [RouterLink, BookTemplateComponent],
  templateUrl: './classifications-page.component.html',
  styleUrl: './classifications-page.component.css'
})
export class ClassificationsPageComponent implements OnInit {
  Menu = Menu;

  HadithCollections: HadithCollection[] = [];
  HadithCollection!: HadithCollection;

  isSingleCollection = false;

  constructor(
    private service: HadithService,
    private route: ActivatedRoute,
    private seo: SeoService
  ) { }
  partitionId!: number;
  collectionId!: number;
  ngOnInit(): void {
    this.partitionId = Number(this.route.snapshot.paramMap.get('partitionId'));
    this.collectionId = Number(this.route.snapshot.paramMap.get('collectionId'));

    if (this.collectionId) {
      this.isSingleCollection = true;
      const res = this.route.snapshot.data['collectionData'];
      if (res?.isSuccess) {
        this.HadithCollection = res.data;
        this.updateSeo(this.HadithCollection);
      }
    } else {
      this.isSingleCollection = false;
      const res = this.route.snapshot.data['collectionsData'];
      if (res?.isSuccess) {
        this.HadithCollections = res.data.items;
      }
    }
  }

  private updateSeo(collection: HadithCollection) {
    this.seo.updateSeoData(
      collection.name || '',
      `تصفح ${collection.name} في جامع السنة وشروحها.`
    );
    this.seo.setStructuredData({
      "@context": "https://schema.org",
      "@type": "Series",
      "name": collection.name,
      "description": `سلسلة أحاديث ${collection.name}`
    });
  }



}
