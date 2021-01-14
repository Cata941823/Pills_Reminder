import { Component, OnInit } from '@angular/core';
import { PillsService, Pastila, Doza } from '../service/pills.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pills',
  templateUrl: './pills.component.html',
  styleUrls: ['./pills.component.css']
})
export class PillsComponent implements OnInit {

  lista_tuturor_pastilelor: Array<Pastila> = null;

  pastilaAleasaInserate;
  cantitatePastileInserate;
  dataAleasaInserate;
  numarZileInserate;
  oraInserate;

  constructor(private pillsService: PillsService, private router: Router) { }

  ngOnInit(): void {
    this.initialisePastile();
    this.getPastile();
  }

  initialisePastile() {
    this.lista_tuturor_pastilelor = this.pillsService.lista_tuturor_pastilelor;
  }

  getPastile() {
    return Promise.resolve(this.pillsService.getAllPastile().subscribe(data => {
      if (data != null) {
        // @ts-ignore
        for (let entry of data) {
          var pastila: Pastila = new Pastila();
          pastila.Id = entry["id"];
          pastila.Denumire = entry["denumire"];
          this.lista_tuturor_pastilelor.push(pastila);
        }
        console.log(this.lista_tuturor_pastilelor);
      }
    }));
  }

  createDoza() {
    let doza: Doza = new Doza();
    doza.Cantitate_pastila = this.cantitatePastileInserate;
    doza.DataInceput = this.dataAleasaInserate;
    doza.NumarZile = this.numarZileInserate;
    doza.Ora = this.oraInserate;

    for (let entry of this.lista_tuturor_pastilelor) {
      console.log(entry);
      if (entry["Denumire"] == this.pastilaAleasaInserate) {
        doza.IdPastila = entry["Id"];
      }
    }

    console.log(doza);
    this.pillsService.createDoza(doza).subscribe(data => {
      if (data != null) {
        this.router.navigate(['doze']);
      }
    });
  }


}
