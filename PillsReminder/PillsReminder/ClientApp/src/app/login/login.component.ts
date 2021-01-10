import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../service/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  Email;
  Parola;

  constructor(private authenticationService: AuthenticationService, private router: Router) { }

  ngOnInit(): void {
  }

  login() {
    this.authenticationService.login(this.Email, this.Parola).subscribe(data => {
      console.log(data['token']);
      if (data['token'] != null) {
          localStorage.setItem("token", data['token']);
        if (localStorage.token != null || localStorage.token != "\"false\"") {
          this.router.navigate(['home']);
        }
      }
    });
  }
}
