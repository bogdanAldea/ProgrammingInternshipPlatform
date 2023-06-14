export class Timeframe 
{
    public scheduledToStartOn: Date;
    public scheduledToEndOn: Date;

    constructor(timframe: Timeframe) 
    {
        this.scheduledToStartOn = timframe.scheduledToStartOn;
        this.scheduledToEndOn = timframe.scheduledToEndOn;
    }
}
