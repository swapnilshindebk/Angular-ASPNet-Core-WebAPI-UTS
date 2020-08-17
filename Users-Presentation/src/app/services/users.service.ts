import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  baseAPIURL: string = 'https://localhost:44399/api/Users/';

  constructor(private httpClient: HttpClient) { }

  getUsers()
  {
    return this.httpClient.get(this.baseAPIURL);
  }

  addUser(newUser: User)
  {
    return this.httpClient.post(this.baseAPIURL, newUser);
  }

  updateUser(userID:number, newUser: User)
  {
    return this.httpClient.put(this.baseAPIURL+ "?id=" + userID, newUser );
  }

  deleteUser(userID: number)
  {
    return this.httpClient.delete(this.baseAPIURL+ "?id="+ userID);
  }

}
