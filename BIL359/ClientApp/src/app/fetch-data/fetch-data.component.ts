import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[] = [];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }

  public text: string | undefined;
  public getData() {
    if (this.forecasts.length > 0){
      this.text = this.forecasts[0].summary
    }
    return this.text ? this.text : "Bulunamadı";
  }
}

interface WeatherForecast {
  summary: string;
}
