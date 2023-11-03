import { HttpParams } from "@angular/common/http";

export class HttpParamsBuilder {
        private httpParams = new HttpParams();
        private submitted: Param[] = [];

        public page = (page: number): this => {
                this.submitted.push({name: 'page', value: page})
                return this;
        }

        public resultsPerPage = (results: number): this => {
                this.submitted.push({name: 'resultsPerPage', value: results})
                return this;
        }

        public submit = (name: string, param?: any | undefined): this => {
                this.submitted.push({name: name, value: param})
                return this;
        }

        public build = (): HttpParams => {
                this.submitted.forEach(param => {
                        if (param.value)
                        this.httpParams = this.httpParams.set(param.name, param.value);
                })
                return this.httpParams;
        }
}

interface Param {
        name: string;
        value?: any;
}