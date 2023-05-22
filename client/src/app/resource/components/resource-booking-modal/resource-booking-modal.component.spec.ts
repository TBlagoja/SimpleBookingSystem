import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResourceBookingModalComponent } from './resource-booking-modal.component';

describe('ResourceBookingModalComponent', () => {
  let component: ResourceBookingModalComponent;
  let fixture: ComponentFixture<ResourceBookingModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResourceBookingModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ResourceBookingModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
