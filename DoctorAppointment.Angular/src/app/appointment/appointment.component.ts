import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,Validators } from '@angular/forms';

@Component({
  selector: 'app-appointment',
  templateUrl: './appointment.component.html',
  styleUrls: ['./appointment.component.css']
})
export class AppointmentComponent implements OnInit {


  public appointmentForm!:FormGroup;
  constructor(private formBuilder:FormBuilder) { }

  ngOnInit(): void {
    this.appointmentForm=this.formBuilder.group({
      firstname :['',Validators.required],
      lastname :['',Validators.required],
      email:['',[Validators.required,Validators.email]],
      date:['',Validators.required],
      time:['',Validators.required],
      mobile:['',[Validators.required,Validators.pattern("^[0-9]{10}")]]
  })

  }
  get f(){
    return this.appointmentForm.controls;
  }

}
