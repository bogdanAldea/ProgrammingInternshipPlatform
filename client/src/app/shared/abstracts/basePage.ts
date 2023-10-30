import { ActivatedRoute } from "@angular/router";

export abstract class BasePage {
    public isLoading: boolean = false;
    public parentGuid: string | undefined;

    public constructor(private readonly router: ActivatedRoute) {}

    public parentIdExistsOnRoute(parentGuid: string | undefined): boolean {
        return parentGuid !== undefined;
      }
    
    public getParentIdFromRoute(): string | undefined {
        return this.router.parent?.snapshot.params['id'];
      }
}