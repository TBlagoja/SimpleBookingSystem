import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Resource } from '../models/resource';
import { BehaviorSubject } from 'rxjs';
import { Booking } from '../models/booking';

@Injectable({
  providedIn: 'root'
})
export class ResourceService {
  baseUrl = 'https://localhost:5001/api/';

  private resourceList = new BehaviorSubject<Resource[] | null>(null);
  resourceList$ = this.resourceList.asObservable();

  constructor(private http: HttpClient) { }

  getResources(){
    return this.http.get<Resource[]>(this.baseUrl + 'resources').subscribe({
      next: resources => this.resourceList.next(resources)
    })
  }

  getResource(id: number){
    return this.http.get<Resource>(this.baseUrl + 'resources/' + id);
  }

  bookResource(booking: Booking){
    return this.http.post<Booking>(this.baseUrl + 'resources/book', booking);
  }
}
