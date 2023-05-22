import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Resource } from '../../models/resource';
import { Booking } from '../../models/booking';
import { ResourceService } from '../../services/resource.service';
import * as moment from 'moment';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-resource-booking-modal',
  templateUrl: './resource-booking-modal.component.html',
  styleUrls: ['./resource-booking-modal.component.scss']
})
export class ResourceBookingModalComponent implements OnInit {
  form!: FormGroup;

  constructor(private fb: FormBuilder,
    private resourceService: ResourceService,
    private toastrService: ToastrService,
    private dialogRef: MatDialogRef<ResourceBookingModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Resource,
    
  ) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      dateFrom: ['', Validators.required],
      dateTo: ['', Validators.required],
      quantity: [0, Validators.required],
      // Add more form controls as needed
    });
  }

  close() {
    this.dialogRef.close();
  }

  submitForm() {
    if (this.form.valid) {
      const formValues = this.form.value;
      const booking: Booking = {
        dateFrom: moment(formValues.dateFrom.toDate()).format('YYYY-MM-DD'), 
        dateTo: moment(formValues.dateTo.toDate()).format('YYYY-MM-DD'), 
        bookedQuantity: formValues.quantity,
        resourceId: this.data.id
      };

      this.resourceService.bookResource(booking).subscribe({
        next: (response) => {
          this.toastrService.success("You have succesfuly booked your resource")
        },
        error: (error) => {
          this.toastrService.error(error.error.validationErrorMessage)
        }
      });
    }
  }
}
