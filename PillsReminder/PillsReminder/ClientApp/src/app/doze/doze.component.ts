import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from "@angular/material/table";
import { MatPaginator } from "@angular/material/paginator";
import { PillsService, Doza, DozajAfisare } from '../service/pills.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-doze',
  templateUrl: './doze.component.html',
  styleUrls: ['./doze.component.css']
})
export class DozeComponent implements OnInit {

  @ViewChild(MatPaginator) paginator: MatPaginator;

  displayedColumns: string[] = ['Cantitate', 'Data', 'Ora', 'Medicament', 'Luata'];
  dataSource: MatTableDataSource<any>;

  lista_pastile_de_luat: Array<DozajAfisare> = null;
  unique_lista_pastile_de_luat: Array<DozajAfisare> = null;

  constructor(private pillsService: PillsService, private router: Router) { }

  ngOnInit(): void {
    this.getAllMedicamentatii();
    this.dataSource.paginator = this.paginator;
  }

  getAllMedicamentatii() {
    this.pillsService.getAllMedicamentatii().subscribe(data => {
      if (data != null) {
        // @ts-ignore
        for (let entry of data) {
          var pastilaDeLuat: DozajAfisare = new DozajAfisare();

          pastilaDeLuat.Cantitate = entry["cantitate_pastila"];
          pastilaDeLuat.Data = entry["data"];
          pastilaDeLuat.Ora = entry["ora"];
          pastilaDeLuat.Medicament = entry["medicament"];
          pastilaDeLuat.Luata = entry["luata"];
          console.log(pastilaDeLuat);
          this.lista_pastile_de_luat.push(pastilaDeLuat);
        }
        this.unique_lista_pastile_de_luat = this.lista_pastile_de_luat.map(ar => JSON.stringify(ar))
          .filter((itm, idx, arr) => arr.indexOf(itm) === idx)
          .map(str => JSON.parse(str));
        this.dataSource = new MatTableDataSource(this.unique_lista_pastile_de_luat);
        this.dataSource.paginator = this.paginator;
      }
    })
  }

}
