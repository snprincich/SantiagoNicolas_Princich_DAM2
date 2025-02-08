import { Component,inject} from '@angular/core';
import {HousingLocationComponent} from '../../components/housing-location/housing-location.component';
import {HousingLocation} from '../../models/housinglocation'
import { CommonModule } from '@angular/common';
import {HousingService} from '../../services/housing.service';
import { Coche } from 'src/app/models/coche';
import { CocheService } from 'src/app/services/coche.service';
import { CochesComponent } from 'src/app/components/coches/coches.component';

@Component({
  selector: 'app-home',
  imports: [CommonModule, HousingLocationComponent, CochesComponent],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  /*housingLocationList: HousingLocation[]=[];
  filteredLocationList: HousingLocation[]=[];*/

  cocheList: Coche[]=[];

  constructor(private cocheService: CocheService) {
    this.cocheService.getAllCoches().then((cocheList: Coche[]) => {
      this.cocheList = cocheList;
    });
  }

  /*constructor(private housingService: HousingService) {
    this.housingService.getAllHousingLocations().then((housingLocationList: HousingLocation[]) => {
      this.housingLocationList = housingLocationList;
      this.filteredLocationList = housingLocationList;
    });
  }*/

  /*filterResults(text: string) {
    if (!text) {
      this.filteredLocationList = this.housingLocationList;
      return;
    }
    
    this.filteredLocationList = this.housingLocationList.filter((housingLocation) =>
      housingLocation?.city.toLowerCase().includes(text.toLowerCase()),
    );
  }*/
  
}
