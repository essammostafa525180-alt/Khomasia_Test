import { Component, OnInit, HostListener } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HadithService } from '../../Services/hadith.service';
import { Partition } from '../../Model/Partition/partition';
import { ApiResponse } from '../../Model/BaseModel/api-response';
import { PartitionsData } from '../../Model/Partition/partitions-data';
import { Menu } from '../../Constants/MenuLabels';
import { SeoService } from '../../Services/seo.service';
import { Classification } from '../../Model/Classification/classification';

@Component({
    selector: 'app-library-page',
    imports: [CommonModule, RouterLink, FormsModule],
    templateUrl: './library-page.component.html',
    styleUrl: './library-page.component.css'
})
export class LibraryPageComponent implements OnInit {
  Menu = Menu; // Expose Menu enum to template
  partitions: Partition[] = [];
  filteredPartitions: Partition[] = [];
  loading: boolean = true;
  activePartitionId: number | null = null;
  activeCollectionId: number | null = null;
  searchQuery: string = '';
  viewMode: 'grid' | 'list' = 'grid';
  showScrollTop: boolean = false;

  constructor(
    private hadithService: HadithService,
    private seo: SeoService
  ) { }

  ngOnInit(): void {
    this.loadLibraryData();
    this.seo.updateSeoData(
      'المكتبة الإسلامية',
      'استكشف المكتبة الإسلامية الشاملة للأحاديث النبوية، الكتب، الشروح، والتصنيفات العلمية.',
      'المكتبة الإسلامية, كتب الحديث, تصنيفات السنة'
    );
  }

  @HostListener('window:scroll', [])
  onWindowScroll() {
    this.showScrollTop = window.pageYOffset > 300;
  }

  loadLibraryData(): void {
    this.loading = true;
    this.hadithService.getAllPartitions().subscribe({
      next: (res: ApiResponse<PartitionsData>) => {
        if (res.isSuccess && res.data) {
          // Filter out Home partition
          this.partitions = res.data.items.filter(p => p.id !== Menu.Home);
          this.filteredPartitions = [...this.partitions];
          // Open first partition by default
          if (this.partitions.length > 0) {
            this.activePartitionId = this.partitions[0].id;
          }
        }
        this.loading = false;
      },
      error: (err) => {
        console.error('Error loading library data:', err);
        this.loading = false;
      }
    });
  }

  togglePartition(id: number): void {
    this.activePartitionId = this.activePartitionId === id ? null : id;
    this.activeCollectionId = null; // Reset collection when changing partition
  }

  toggleCollection(id: number): void {
    this.activeCollectionId = this.activeCollectionId === id ? null : id;
  }

  onSearch(): void {
    const query = this.searchQuery.toLowerCase().trim();
    if (!query) {
      this.filteredPartitions = [...this.partitions];
      return;
    }

    this.filteredPartitions = this.partitions.filter(partition => {
      // Search in partition name
      if (partition.name?.toLowerCase().includes(query)) {
        return true;
      }

      // Search in collections and classifications
      return partition.hadithCollections?.some(collection => {
        if (collection.name?.toLowerCase().includes(query)) {
          return true;
        }
        return collection.classifications?.some(classification =>
          classification.name?.toLowerCase().includes(query)
        );
      });
    });
  }

    getTopClassifications(classifications: Classification[]): Classification[] {
    return [...classifications]
      .sort((a, b) => {
        const yearA = parseInt(a.deathYear, 10) || Number.MAX_SAFE_INTEGER;
        const yearB = parseInt(b.deathYear, 10) || Number.MAX_SAFE_INTEGER;
        return yearA - yearB;
      });
  }
  resetSearch(): void {
    this.searchQuery = '';
    this.filteredPartitions = [...this.partitions];
  }

  getTotalCollections(): number {
    return this.partitions.reduce((total, partition) =>
      total + (partition.hadithCollections?.length || 0), 0
    );
  }

  getTotalClassifications(): number {
    return this.partitions.reduce((total, partition) =>
      total + (partition.hadithCollections?.reduce((sum, collection) =>
        sum + (collection.classifications?.length || 0), 0) || 0), 0
    );
  }

  getPartitionClassificationsCount(partition: Partition): number {
    return partition.hadithCollections?.reduce((sum, collection) =>
      sum + (collection.classifications?.length || 0), 0) || 0;
  }

  scrollToTop(): void {
    window.scrollTo({ top: 0, behavior: 'smooth' });
  }
}
