import { Component, OnInit } from '@angular/core';
import { Resource } from '../../models/resource';
import { ResourceService } from '../../services/resource.service';
import { MatDialog } from '@angular/material/dialog';
import { ResourceBookingModalComponent } from '../resource-booking-modal/resource-booking-modal.component';

@Component({
  selector: 'app-resource',
  templateUrl: './resource.component.html',
  styleUrls: ['./resource.component.scss']
})
export class ResourceComponent implements OnInit {
  shouldOpen = false;
  resources: Resource[] = [];

  resource: Resource = {
    id: 0,
    name: '',
    quantity: 0
  }

  constructor(public resourceService: ResourceService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.resourceService.resourceList$.subscribe({
      next: response => response !== null ? this.resources = response : this.resources = []
    })
  }

  openModal(id: number) {
    this.resourceService.getResource(id).subscribe({
      next: response => {
        this.dialog.open(ResourceBookingModalComponent, {
          width: '400px',
          data: response 
        });
      }
    })
  }
}
