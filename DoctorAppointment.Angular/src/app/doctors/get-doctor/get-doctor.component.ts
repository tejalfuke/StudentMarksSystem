import { Component, OnInit } from '@angular/core';
import { BookappointmentService } from 'src/app/services/bookappointment.service';

@Component({
  selector: 'app-get-doctor',
  templateUrl: './get-doctor.component.html',
  styleUrls: ['./get-doctor.component.css']
})
export class GetDoctorComponent implements OnInit {
  doctors$:any;
  searchText: string='';

  constructor(private bookappointmentService : BookappointmentService) { }

  ngOnInit(): void {
    this.bookappointmentService.getDoctorDetails().subscribe({
      next :(data)=>{
        this.doctors$=data;
      },
      complete:() =>{
        console.log("completed");
      },
      error:(err)=>{
        console.log("Unable to fetch movies"+err);
      }

    });

  }
  }


