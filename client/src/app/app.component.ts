import { Component, OnInit } from '@angular/core';
import { ResourceService } from './resource/services/resource.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'client';

  constructor(private resourceService: ResourceService) { }

  ngOnInit(): void {
    this.loadResources();
  }

  loadResources(){
    this.resourceService.getResources();
  }
}
