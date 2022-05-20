import { Component, OnInit } from '@angular/core';
import { BookappointmentService } from 'src/app/services/bookappointment.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private service:BookappointmentService) { }
   doctorData:any;
  ngOnInit(): void {
    this.doctorData=this.service.doctorDetails;
  }

}
