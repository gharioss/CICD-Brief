import { Component, OnInit } from '@angular/core';
import { SchoolApiService } from '../school-api.service';
import { __values } from 'tslib';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-motivation',
  templateUrl: './motivation.component.html',
  styleUrls: ['./motivation.component.css']
})
export class MotivationComponent implements OnInit {
  public resultObject?:any = null;
  constructor(private service:SchoolApiService) { }

  ngOnInit(): void {

    this.postIdInputDetails();
    // console.log(this.resultObject);
  }

  postIdInputDetails(idInput?:number) {
    this.service.postIdDetailsSearch().subscribe((res: any) => {
      this.resultObject = res;
      // this.jobList = (res.listEtablissement);
    });
  };

}
