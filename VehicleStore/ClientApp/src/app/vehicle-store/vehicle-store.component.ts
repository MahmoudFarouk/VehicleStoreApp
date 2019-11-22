import { Component, OnInit, ChangeDetectorRef, AfterViewInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Vehicle } from './models/vehicle.model'
import { Customer } from './models/customer.model'
import { VehicleStoreService } from './vehicle-store.service'

@Component({
    selector: 'app-vehicle-store',
    templateUrl: './vehicle-store.component.html',
})

export class VehicleStoreComponent implements AfterViewInit {

    public vehicles: Vehicle[] = [];
    public customers: Customer[];
    public isConnected: boolean;
    public selectedCustomer: number;
    public baseUrl: string;

    constructor(private http: HttpClient, private cdr: ChangeDetectorRef, private vehicleService: VehicleStoreService) { }

    ngOnInit() {
        this.getAllCustomers();
        this.getAllVehicles();

        setInterval(() => {
            this.updateVehicleStatus();
            this.getAllVehicles();
        }, 60000)
    }

    ngAfterViewInit() {
        this.cdr.detectChanges();
    }

    getAllVehicles() {
        this.vehicleService.getAllVehicles().subscribe(result => {
            result.data.map((vehicle) => { vehicle.date = new Date(Date.now()) });
            this.vehicles = [...this.vehicles, ...result.data];
        })
    }

    getAllCustomers() {
        this.vehicleService.getAllCustomers().subscribe(result => {
            this.customers = result.data;
        });
    }

    updateVehicleStatus() {
        this.vehicleService.updateVehicleStatus().subscribe(result => {
            var vehicleslogDiv = document.getElementById("vehicleslog");
            vehicleslogDiv.scrollTop = vehicleslogDiv.scrollHeight;
        });
    }

    resetForm() {
        this.isConnected = undefined;
        this.selectedCustomer = undefined;
        this.vehicles = [];
        this.getAllVehicles();
    }
}
