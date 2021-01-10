import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService, Utilizator } from '../service/authentication.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  Nume;
  Prenume;
  Email;
  Parola;

  catreLogin: string = "/register";

  constructor(private authenticationService: AuthenticationService, private router: Router) { }

  ngOnInit(): void {
  }

  signUp() {
    let user: Utilizator = new Utilizator();
    user.Nume = this.Nume;
    user.Prenume = this.Prenume;
    user.Email = this.Email;
    user.Parola = this.Parola;

    this.authenticationService.signUp(user).subscribe(data => {
      if(data != null){
        this.router.navigate(['login']);
      }
    });
  }
}
