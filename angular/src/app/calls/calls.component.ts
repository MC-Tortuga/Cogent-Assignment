import { Component, Injector, ViewChild } from "@angular/core";
import { AppComponentBase } from "@shared/app-component-base";
import { appModuleAnimation } from "@shared/animations/routerTransition"
import { CallServiceProxy, CallDto, PagedResultDtoOfCallDto } from "@shared/service-proxies/service-proxies";
import { PagedListingComponentBase, PagedRequestDto, PagedResultDto } from "@shared/paged-listing-component-base";
import { CreateCallComponent } from "./create-call/create-call.component"
import { finalize } from "rxjs/operators";
import { EditCallComponent } from "@app/calls/edit-call/edit-call.component";


@Component({
    templateUrl: "./calls.component.html",
    animations: [appModuleAnimation()]
})
export class CallsComponent extends PagedListingComponentBase<CallDto> {

    @ViewChild('createCallModal') createCallModal: CreateCallComponent;
    @ViewChild('editCallModal') editCallModal: EditCallComponent;

    calls: CallDto[] = [];
    call: CallDto = new CallDto();
    constructor(injector: Injector, private _callService: CallServiceProxy) {
        super(injector);

    }

    list(
        request: PagedRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {
        this._callService
            .getAll(request.skipCount, request.maxResultCount)
            .pipe(finalize(() => finishedCallback()))
            .subscribe((result: PagedResultDto) => {
                this.calls = result.items
                this.showPaging(result, pageNumber);
            });
    }

    protected delete(entity: CallDto): void {
        abp.message.confirm("Delete Call entry " + entity.callNumber, (result: boolean) => {
            if (result) {
                this._callService
                    .delete(entity.id)
                    .pipe(finalize(() => {
                        abp.notify.info("Deleted Number " + entity.callNumber);
                        this.refresh();
                    }))
                    .subscribe(() => { });
            }
        });
    }

    protected createcall(): void {
        this.createCallModal.show();
    }
    protected editCall(callDto: CallDto): void {

        this.editCallModal.show(callDto.id);
    }
}
