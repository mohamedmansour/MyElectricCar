***Currently in progress***

# MyElectricCar
Having an Electric Car is beautiful, the BMW i3 is actually my first car. I love that it runs on electricity
but I also hate that ChargePoint charges per hour. For the i3, it charges 6 kwatts/hour. But during the end 
of the charge, it decreases exponentially to like 1 kwatt/hour. 

Lets say I pay $1 per hour to charge, and my BMW accepts around 20 kwatts. It will take around 3 hours to 
get a full charge. But with chargepoint tries to charge for 6 hours. Paying double the money. The extra 
3 hours of charge was for the last 10%.

I created this Windows 10 app so that I can spend 50% less money on charging. The way it works is pretty
simple, when it decreases charging output, I stop charging right away, so I can maximize the amount of 
energy going in for my money. It ends up charging 90%-95% of the vehicle.

## How it is done
I currently reverse engineered the ChargePoint app to get access to the private APIs. It is technically
not reverse engineering, I just man in the middled the ChargePoint iOS app to get acccess to the 
underlying APIs. 

Then I used these APIs to crawl my charge status for my profile. Then after I rech the maximum 
charge for my money, I terminate the charge ASAP before I get charged more.

## Future work
- Create a nicer interface. I am just coding for proof of concept, then I will make it pretty.
- Integrate into Cortana, so I can tell it, "Hey Cortana, whats my charge?"
- Get nice stats out of the charging.


