import { Component, Input} from "@angular/core";

@Component({
    selector: "in-busy-spin",
    templateUrl: "./inbusyspinner.component.html",
    styleUrls:["./inbusyspinner.component.scss"]
})
export class InBusySpinnerComponent{
    @Input("text") text: string = '';
    @Input("isBusy") isBusy: boolean = false;
}