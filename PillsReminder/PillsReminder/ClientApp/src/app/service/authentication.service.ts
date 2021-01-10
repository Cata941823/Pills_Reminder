import { HttpClient, HttpRequest, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Observable} from "rxjs";

export class Utilizator {
  Nume;
  Prenume;
  Email;
  Parola;
}

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  baseUrl = "http://localhost:58277";

  constructor(private httpClient: HttpClient) { }

  signUp(user): Observable<HttpRequest<any>> {
    let url = "https://localhost:5001/api/Auth/register";
    let payload = {data: user};
    return this.httpClient.post<any>(url, payload.data, {responseType: 'text' as 'json'});
  }

  login(Email, Parola): Observable<HttpResponse<any>> {
    let url = "https://localhost:5001/api/Auth/login";
    let payload = {
      Email: Email,
      Parola: Parola
    };
    return this.httpClient.post<any>(url, payload);
  }
}
