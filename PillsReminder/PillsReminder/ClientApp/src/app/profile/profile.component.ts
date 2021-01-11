import { Component, OnInit } from '@angular/core';
import { ProfileService, UpdateUtilizator } from '../service/profile.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  NumeDeAfisat;
  PrenumeDeAfisat;
  EmailDeAfisat;

  NumeUpdate;
  PrenumeUpdate;
  ParolaUpdate;

  constructor(private profileService: ProfileService, private router: Router) { }

  ngOnInit(): void {
    this.afisareDateUtilizatorLogat();
  }

  afisareDateUtilizatorLogat() {
    this.profileService.getUtilizatorLogat().subscribe(data => {
      console.log(data);
        this.NumeDeAfisat = data['nume'];
        this.PrenumeDeAfisat = data['prenume'];
        this.EmailDeAfisat = data['email'];
    });
  }

  signOut() {
    localStorage.removeItem("token");
    window.location.reload();
  }

  updateProfile() {
    let user: UpdateUtilizator = new UpdateUtilizator();
    user.Nume = this.NumeUpdate;
    user.Prenume = this.PrenumeUpdate;
    user.Parola = this.ParolaUpdate;

    this.profileService.update(user).subscribe(data => {
      if (data != null) {
        window.location.reload();
      }
    });
  }
  validateForm() {
    if (this.NumeUpdate == null || this.PrenumeUpdate == null || this.ParolaUpdate == null) {
      alert("Completeaza toate campurile!");
      return false;
    }
    else {
      this.updateProfile();
    }
  }

  deleteAccount() {
    if (confirm('Esti sigur ca doresti sa stergi contul?')) {
      this.profileService.delete().subscribe(data => {
        localStorage.clear();
        window.location.reload();
      })      
    }
  }
}
