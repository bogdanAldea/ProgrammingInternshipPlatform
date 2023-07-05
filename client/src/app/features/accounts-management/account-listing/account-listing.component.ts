import { Component, OnInit } from '@angular/core';
import { AccountResponse } from '../core/interfaces/account-response';
import { Observable } from 'rxjs';
import { AccountsService } from '../core/services/accounts.service';
import { AccountWithRoles } from '../core/interfaces/account-with-roles';

@Component({
  selector: 'app-account-listing',
  templateUrl: './account-listing.component.html',
  styleUrls: ['./account-listing.component.scss']
})
export class AccountListingComponent implements OnInit {
  public accounts: AccountResponse[] = [];
  public accounts$!: Observable<AccountWithRoles[]>

  public constructor(private service: AccountsService){}

  public ngOnInit(): void {
    // this.accounts.push(
    //   {
    //     firstName: "Michael",
    //     lastName: "Scott",
    //     email: "scott@gmail.com",
    //     joiningDate: 'June 04, 2023',
    //     roles: ['Admin']
    //   },

    //   {
    //     firstName: "Michael",
    //     lastName: "Scott",
    //     email: "scott@gmail.com",
    //     joiningDate: 'June 04, 2023',
    //     roles: ['Admin']
    //   },

    //   {
    //     firstName: "Michael",
    //     lastName: "Scott",
    //     email: "scott@gmail.com",
    //     joiningDate: 'June 04, 2023',
    //     roles: ['Admin']
    //   },

    //   {
    //     firstName: "Michael",
    //     lastName: "Scott",
    //     email: "scott@gmail.com",
    //     joiningDate: 'June 04, 2023',
    //     roles: ['Admin']
    //   },

    //   {
    //     firstName: "Michael",
    //     lastName: "Scott",
    //     email: "scott@gmail.com",
    //     joiningDate: 'June 04, 2023',
    //     roles: ['Admin']
    //   },

    //   {
    //     firstName: "Michael",
    //     lastName: "Scott",
    //     email: "scott@gmail.com",
    //     joiningDate: 'June 04, 2023',
    //     roles: ['Admin']
    //   }

    // );
    this.accounts$ = this.service
      .getAllAccountsAtOrganisation('b4f75fed-37bf-40fc-a8b3-f071b41a3fc1');
      console.log(this.accounts$)
  }
}
