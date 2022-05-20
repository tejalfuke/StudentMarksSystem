import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder,Validators } from '@angular/forms';

@Component({
  selector: 'app-student-result',
  templateUrl: './student-result.component.html',
  styleUrls: ['./student-result.component.css']
})
export class StudentResultComponent {

  public Maths:number=0;
  public Physics:number=0;
  public Chemistry:number=0;
  public average:number=0;

  Average(){
    this.average=(this.Maths+this.Physics+this.Chemistry)/3;
  }

//   public studentDetails!:FormGroup;
//   constructor(private formBuilder:FormBuilder) { }

//   ngOnInit(): void {

//     this.studentDetails=this.formBuilder.group({
//       FirstName :['',Validators.required],
//       LastName :['',Validators.required],
//       email:['',[Validators.required,Validators.email]],
//       RollNumber:['',Validators.required],
      
//   })
// }
// get f(){
//   return this.studentDetails.controls;
// }
}
  




