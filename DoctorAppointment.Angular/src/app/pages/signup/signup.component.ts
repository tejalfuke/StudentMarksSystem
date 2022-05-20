import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,Validators } from '@angular/forms';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  public signupForm!:FormGroup;
  constructor(private formBuilder:FormBuilder) { }

  ngOnInit(): void {
    this.signupForm=this.formBuilder.group({
      fullname :['',Validators.required],
      email:['',[Validators.required,Validators.email]],
      password:['',Validators.required],
      mobile:['',[Validators.required,Validators.pattern("^[0-9]{10}")]]
  })

}
get f(){
  return this.signupForm.controls;
}
}
