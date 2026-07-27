import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { Partition } from '../../Model/Partition/partition';
import { Classification } from '../../Model/Classification/classification';
import { RouterLink } from "@angular/router";
import { Menu } from '../../Constants/MenuLabels';

@Component({
  selector: 'app-drop-down',
  imports: [CommonModule, RouterLink],
  templateUrl: './menus-desktop.component.html',
  styleUrl: './menus-desktop.component.css'
})
export class DropDownComponent {
  Menu = Menu;

  @Input({ required: true }) partitions!: Partition[];
  @Input() isOpen = false;

   getTopClassifications(classifications: Classification[]): Classification[] {
    return [...classifications]
      .sort((a, b) => {
        const yearA = parseInt(a.deathYear, 10) || Number.MAX_SAFE_INTEGER;
        const yearB = parseInt(b.deathYear, 10) || Number.MAX_SAFE_INTEGER;
        return yearA - yearB;
      })
      .slice(0, 10);
  }
}
