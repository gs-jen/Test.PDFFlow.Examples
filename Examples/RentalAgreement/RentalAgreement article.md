##### Example: Rental Agreement

**Rental Agreement** project is an example of creating a **“Rental Agreement”** document. The example shows how to create a complex document that includes tables, nested tables, and lists. Also it shows one of the ways to display forms for manual filling of a printed document.

The example source is available in [repo](https://github.com/gehtsoft-usa/PDF.Flow.Examples/tree/master/Examples/RentalAgreement).

**Table of Content**  

- [Prerequisites](#prerequisites)
- [Purpose](#purpose)
- [Description](#description)
- [Output file](#output-file)
- [Open the project in Visual Studio](#1-open-the-project-in-visual-studio)
- [Run the sample application](#2-run-the-sample-application)
- [Source code structure](#3-source-code-structure)
- [Adding the Data](#4-adding-the-data)
- [The Program class](#5-the-program-class)
- [The RentalAgreementRunner class](#6-the-rentalagreementrunner-class)
- [The RentalAgreementBuilder class](#7-the-rentalagreementbuilder-class)
- [The RentalAgreementTextBuilder class](#8the-rentalagreementtextbuilder-class)
- [The RentalAgreementHelperBuilder class](#9-the-rentalagreementhelperbuilder-class)
- [The RentalAgreementAmountBuilder class](#10-the-rentalagreementamountbuilder-class)
- [The RentalAgreementCheckListBuilder class](#11-the-rentalagreementchecklistbuilder-class)
- [Summary](#summary)

# Prerequisites

1. **Visual Studio 2017** or later is installed.
   To install a community version of Visual Studio, use the following link: https://visualstudio.microsoft.com/vs/community/.
   Please make sure that the way you are going to use Visual Studio is allowed by the community license. You may need to buy Standard or Professional Edition.

2. **.NET Core Framework SDK 2.1** or later is installed.
   To install the framework, use the following link: https://dotnet.microsoft.com/download.

# Purpose

The example shows how to create a “Rental Agreement” that is a complex fifteen-page document.

The document consists of:

* Nine text pages
* Signature page
* Security Deposit Receipt page
* AMOUNT ($) DUE AT SIGNING page
* Three Move-in Checklist pages

# Description

#### Output file

The example creates the **RentalAgreement.pdf** file in the output **bin/(debug|release)/netcoreapp2.1** folder, unless specified otherwise in the command line.

#### 1. Open the project in Visual Studio

There are two ways to open the project:

* After installing Visual Studio, double-click the project file **RentalAgreement.csproj**.

* In Visual Studio, select **File** > **Open** > **Project/Solution** > **RentalAgreement.csproj**. 

#### 2. Run the sample application

There are two ways to run the sample application:

* From Visual Studio by clicking **F5**.

* From a command line: in the directory with **RentalAgreement.csproj**, run the command: 

```
dotnet run
```

You can get optional parameters of the command line using the command:

```
dotnet run -help
```

that shows the specification of the command line options:

```
Usage: dotnet run [fullPathToOutFile] [appToView]
Where: fullPathToOutFile - a path to the result file, 'RentalAgreement.pdf' by default
appToView - the name of an application to view the file immediately after preparing, by default none app starts
```

## 3. Source code structure

The source code consists of several files (classes).

The reasons to write several classes are the following (in descending order of priority):

* Separation of responsibility. The class `Program` processes the command line options, any possible errors during the document creation, and displays the error report. The other classes do not process the command line options and errors. They are used to build the document itself.
* Reduction of responsibility of each class. This helps to limit the size of code for each class, which improves understanding of the code example.
* Independent blocks of content. The document consists of several content blocks which are independent, so for each class you can select its own block.

## 4. Adding the Data

* The data used in the document is stored in json files and processed in the related model files. Create the folowing files.

  * **Content/ra-agreement.json** file:

    ```json
    {
      "Date": "2020-12-09T00:00:00",
      "AptAddress": "1 Main Street, Apt 4, Small Town, Alabama, 20992",
      "AptFeaturesBath": "2.5 bathroom(s)",
      "AptFeatures": "2 bedroom(s)",
      "AptFurnishing": "Bedroom Set(s), Dining Room Set(s), Living Room Set(s)",
      "Appliances": "Air Conditioner(s), Dishwasher, Dryer (for Laundry), Fan(s), Hot Water Heater, HVAC, Microwave, Outdoor Grill, Oven(s), Refrigerator, Stove(s), Washer (for Laundry)",
      "DateBegin": "2020-12-03T00:00:00",
      "DateEnd": "2033-11-29T00:00:00",
      "CancelNoticePeriodDays": "thirty (30)",
      "ContinueNoticePeriondDays": "sixty (60)",
      "MonthPayment": 1873,
      "NonsufficientFundsFee": 45,
      "LateFee": 50,
      "SecurityDeposit": 1873,
      "RightToBuyPrice": 450000,
      "RightToBuyDeposit": 4500,
      "AbandonmentPeriod": "seven (7) days",
      "ParkingSpace": "2 Parking Spaces",
      "ParkingSpaceDescription": "1 outdoor parking space and 1 indoor garage parking space provided",
      "TerminationPeriod": 60,
      "TerminationFee": 1000,
      "PetsAllowed": "Two (2) pets",
      "PetsFee": 300,
      "ArmedForcesNotice": "thirty (30) days",
      "LawsState": "North Carolina"
    }
    ```

  * **Model/AgreementData.cs** file:

    ```c#
    namespace RentalAgreement.Model
    {
        public class AgreementData
        {
    
            public DateTime Date { get; set; }
            public string AptAddress { get; set; }
            public string AptFeaturesBath { get; set; }
            public string AptFeatures { get; set; }
            public string AptFurnishing { get; set; }
            public string Appliances { get; set; }
            public DateTime DateBegin { get; set; }
            public DateTime DateEnd { get; set; }
            public string CancelNoticePeriodDays { get; set; }
            public string ContinueNoticePeriondDays { get; set; }
            public double MonthPayment { get; set; }
            public double NonsufficientFundsFee { get; set; }
            public double LateFee { get; set; }
            public double SecurityDeposit { get; set; }
            public double RightToBuyPrice { get; set; }
            public double RightToBuyDeposit { get; set; }
            public string AbandonmentPeriod { get; set; }
            public string ParkingSpace { get; set; }
            public string ParkingSpaceDescription { get; set; }
            public int TerminationPeriod { get; set; }
            public double TerminationFee { get; set; }
            public string PetsAllowed { get; set; }
            public double PetsFee { get; set; }
            public string ArmedForcesNotice { get; set; }
            public string LawsState { get; set; }
    
    
            public override string ToString() 
            {
                return  "AgreementData{" +  
                        "Date=" + Date +
                        ", AptAddress=" + AptAddress +
                        ", AptFeaturesBath=" + AptFeaturesBath +
                        ", AptFeatures=" + AptFeatures +
                        ", AptFurnishing=" + AptFurnishing +
                        ", Appliances=" + Appliances +
                        ", DateBegin=" + DateBegin +
                        ", DateEnd=" + DateEnd +
                        ", CancelNoticePeriodDays=" + CancelNoticePeriodDays +
                        ", ContinueNoticePeriondDays=" + ContinueNoticePeriondDays +
                        ", MonthPayment=" + MonthPayment +
                        ", NonsufficientFundsFee=" + NonsufficientFundsFee +
                        ", LateFee=" + LateFee +
                        ", SecurityDeposit=" + SecurityDeposit +
                        ", RightToBuyPrice=" + RightToBuyPrice +
                        ", RightToBuyDeposit=" + RightToBuyDeposit +
                        ", AbandonmentPeriod=" + AbandonmentPeriod +
                        ", ParkingSpace=" + ParkingSpace +
                        ", ParkingSpaceDescription=" + ParkingSpaceDescription +
                        ", TerminationPeriod=" + TerminationPeriod +
                        ", TerminationFee=" + TerminationFee +
                        ", PetsAllowed=" + PetsAllowed +
                        ", PetsFee=" + PetsFee +
                        ", ArmedForcesNotice=" + ArmedForcesNotice +
                        ", LawsState=" + LawsState +
                        "}";
            }
        }
    }
    ```
    
  * **Content/ra-agreement-text.json** file:

    ```json
    [
      {
        "Header": "OCCUPANT(S):",
        "Text": [
          "The Premises is to be occupied strictly as a residential dwelling with the following Two (2) Occupants to reside on the Premises in addition to the Tenant(s) mentioned above: {tenantAdd.knownAs.asList}, hereinafter known as the “Occupant(s)”."
        ]
      },
      {
        "Header": "OFFER TO RENT:",
        "Text": [
          "The Landlord hereby rents to the Tenant(s), subject to the following terms and conditions of this Agreement, an apartment with the address of {agreement.aptAddress} consisting of {agreement.aptFeatures} hereinafter known as the “Premises”. The Landlord may also use the address for notices sent to the Tenant(s)."
        ]
      },
      {
        "Header": "PURPOSE:",
        "Text": [
          "The Tenant(s) and any Occupant(s) may only use the Premises as a residential dwelling. It may not be used for storage, manufacturing of any type of food or product, professional service(s), or for any commercial use unless otherwise stated in this Agreement."
          ]
      },
      {
        "Header": "FURNISHINGS:",
        "Text": [
          "The Premises is furnished with the following:",
          "{agreement.aptFurnishing} and all other furnishings to be provided by the Tenant(s). Any damage to the Landlord's furnishings shall be the liability of the Tenant(s), reasonable wear-and-tear excepted, to be billed directly or less the Security Deposit."
        ]
      },
      {
        "Header": "APPLIANCES:",
        "Text": [
          "The Landlord shall provide the following appliances:",
          "{agreement.appliances}, and any other unnamed appliances existing on the Premises. Any damage to the Landlord's appliances shall be the liability of the Tenant(s), reasonable wear-and-tear excepted, to be billed directly or less the Security Deposit."
        ]
      },
      {
        "Header": "LEASE TERM:",
        "Text": [
          "This Agreement shall be a fixed-period arrangement beginning on {agreement.dateBegin} and ending on {agreement.dateEnd} with the Tenant(s) having the option to continue to occupy the Premises under the same terms and conditions of this Agreement under a Month-to-Month arrangement (Tenancy at Will) with either the Landlord or Tenant having the option to cancel the tenancy with at least {agreement.cancelNoticePeriodDays} days notice or the minimum time-period set by the State, whichever is shorter. For the Tenant to continue under Month-to-Month tenancy at the expiration of the Lease Term, the Landlord must be notified within {agreement.continueNoticePeriondDays} days before the end of the Lease Term. Hereinafter known as the “Lease Term”."
        ]
      },
      {
        "Header": "RENT:",
        "Text": [
          "Tenant(s) shall pay the Landlord in equal monthly installments of {agreement.monthPayment} (US Dollars) hereinafter known as the “Rent”. The Rent will be due on the First (1st) of every month and be paid through an electronic payment known as Automated Clearing House or “ACH”. Details of the Tenant's banking information and authorization shall be attached to this Lease Agreement." 
        ]
      },
      {
        "Header": "NON-SUFFICIENT FUNDS (NSF CHECKS):",
        "Text": [
          "If the Tenant(s) attempts to pay the rent with a check that is not honored or an electronic transaction (ACH) due to insufficient funds (NSF) there shall be a fee of {agreement.nonsufficientFundsFee} (US Dollars)."
        ]
      },
      {
        "Header": "LATE FEE:",
        "Text": [
          "If rent is not paid on the due date, there shall be a late fee assessed by the Landlord in the amount of:",
          "{agreement.lateFee} (US Dollars) per occurrence for each month payment that is late after the 3rd Day rent is due."
        ]
      },
      {
        "Header": "FIRST (1ST) MONTH'S RENT:",
        "Text": [
          "First (1st) month's rent shall be due by the Tenant(s) upon the execution of this Agreement."
        ]
      },
      {
        "Header": "PRE-PAYMENT:",
        "Text": [
          "The Landlord shall not require any pre-payment of rent by the Tenant(s)."
        ]
      },
      {
        "Header": "PRORATION PERIOD:",
        "Text": [
          "The Tenant(s) will not move into the Premises before the start of the Lease Term."
        ]
      },
      {
        "Header": "SECURITY DEPOSIT:",
        "Text": [
          "A Security Deposit in the amount of {agreement.securityDeposit} (US Dollars) shall be required by the Tenant(s) at the execution of this Agreement to the Landlord for the faithful performance of all the terms and conditions. The Security Deposit is to be returned to the Tenant(s) within 14 days after this Agreement has terminated, less any damage charges and without interest. This Security Deposit shall not be credited towards rent unless the Landlord gives their written consent."
        ]
      },
      {
        "Header": "POSSESSION:",
        "Text": [
          "Tenant(s) has examined the condition of the Premises and by taking possession acknowledges that they have accepted the Premises in good order and in its current condition except as herein otherwise stated. Failure of the Landlord to deliver possession of the Premises at the start of the Lease Term to the Tenant(s) shall terminate this Agreement at the option of the Tenant(s). Furthermore, under such failure to deliver possession by the Landlord, and if the Tenant(s) cancels this Agreement, the Security Deposit (if any) shall be returned to the Tenant(s) along with any other pre-paid rent, fees, including if the Tenant(s) paid a fee during the application process before the execution of this Agreement."
        ]
      },
      {
        "Header": "OPTION TO PURCHASE.",
        "Text": [
          "The Tenant(s) shall have the right to purchase the Premises described herein for {agreement.rightToBuyPrice} at any time during the course of the Lease Term, along with any renewal periods or extensions, by providing written notice to the Landlord along with a deposit of {agreement.rightToBuyDeposit} that is subject to the terms and conditions of a Purchase and Sale Agreement to be negotiated, in “good faith”, between the Landlord and Tenant(s).",
          "If the Landlord and Tenant(s) cannot produce a signed Purchase and Sale Agreement within a reasonable time period then the deposit shall be refunded to the Tenant(s) and this Lease Agreement shall continue under its terms and conditions.",
          "If the option to purchase is exercised by the Tenant(s) all Rent that is paid to the Landlord shall remain separate from any and all deposits, consideration, or payments, made to the Landlord in regards to the purchase of the Premises."
        ]
      },
      {
        "Header": "RECORDING.",
        "Text": [
          "The Tenant(s) shall be withheld from recording this Option to Purchase unless the Tenant(s) has the written consent from the Landlord."
        ]
      },
      {
        "Header": "ACCESS:",
        "Text": [
          "Upon the beginning of the Proration Period or the start of the Lease Term, whichever is earlier, the Landlord agrees to give access to the Tenant(s) in the form of keys, fobs, cards, or any type of keyless security entry as needed to enter the common areas and the Premises. Duplicate copies of the access provided may only be authorized under the consent of the Landlord and, if any replacements are needed, the Landlord may provide them for a fee. At the end of this Agreement all access provided to the Tenant(s) shall be returned to the Landlord or a fee will be charged to the Tenant(s) or the fee will be subtracted from the Security Deposit."
        ]
      },
      {
        "Header": "MOVE-IN INSPECTION:",
        "Text": [
          "Before, at the time of the Tenant(s) accepting possession, or shortly thereafter, the Landlord and Tenant(s) shall perform an inspection documenting the present condition of all appliances, fixtures, furniture, and any existing damage within the Premises."
        ]
      },
      {
        "Header": "SUBLETTING:",
        "Text": [
          "The Tenant(s) shall not have the right to sub-let the Premises or any part thereof without the prior written consent of the Landlord. If consent is granted by the Landlord, the Tenant(s) will be responsible for all actions and liabilities of the Sublessee including but not limited to: damage to the Premises, non-payment of rent, and any eviction process (In the event of an eviction the Tenant(s) shall be responsible for all court filing fee(s), representation, and any other fee(s) associated with removing the Sublessee). The consent by the Landlord to one sub-let shall not be deemed to be consent to any subsequent subletting."
        ]
      },
      {
        "Header": "ABANDONMENT:",
        "Text": [
          "If the Tenant(s) vacates or abandons the property for a time-period that is the minimum set by State law or {agreement.abandonmentPeriod}, whichever is less, the Landlord shall have the right to terminate this Agreement immediately and remove all belongings including any personal property off of the Premises. If the Tenant(s) vacates or abandons the property, the Landlord shall immediately have the right to terminate this Agreement."
        ]
      },
      {
        "Header": "ASSIGNMENT:",
        "Text": [
          "Tenant(s) shall not assign this Lease without the prior written consent of the Landlord. The consent by the Landlord to one assignment shall not be deemed to be consent to any subsequent assignment."
        ]
      },
      {
        "Header": "PARKING:",
        "Text": [
          "The Landlord shall provide the Tenant(s) {agreement.parkingSpace}.",
          "The Landlord shall not charge a fee for the {agreement.parkingSpace}. The Parking Space(s) can be described as: {agreement.parkingSpaceDescription}"
        ]
      },
      {
        "Header": "RIGHT OF ENTRY:",
        "Text": [
          "The Landlord shall have the right to enter the Premises during normal working hours by providing notice in accordance with the minimum State requirement in order for inspection, make necessary repairs, alterations or improvements, to supply services as agreed or for any reasonable purpose. The Landlord may exhibit the Premises to prospective purchasers, mortgagees, or lessees upon reasonable notice."
        ]
      },
      {
        "Header": "SALE OF PROPERTY:",
        "Text": [
          "If the Premises is sold, the Tenant(s) is to be notified of the new Owner, and if there is a new Manager, their contact details for repairs and maintenance shall be forwarded. If the Premises is conveyed to another party, the new owner shall not have the right to terminate this Agreement and it shall continue under the terms and conditions agreed upon by the Landlord and Tenant(s)."
        ]
      },
      {
        "Header": "UTILITIES:",
        "Text": [
          "The Landlord agrees to pay for the following utilities and services:",
          "Lawn Care, Snow Removal, Trash Removal, Water, and the Landlord shall also provideSome great services with all other utilities and services to be the responsibility of the Tenant(s)."
        ]
      },
      {
        "Header": "MAINTENANCE, REPAIRS, OR ALTERATIONS:",
        "Text": [
          "The Tenant(s) shall, at their own expense and at all times, maintain the Premises in a clean and sanitary manner, and shall surrender the same at termination hereof, in as good condition as received, normal wear and tear excepted. The Tenant(s) may not make any alterations to the leased Premises without the consent in writing of the Landlord. The Landlord shall be responsible for repairs to the interior and exterior of the building. If the Premises includes a washer, dryer, freezer, dehumidifier unit and/or air conditioning unit, the Landlord makes no warranty as to the repair or replacement of units if one or all shall fail to operate. The Landlord will place fresh batteries in all battery-operated smoke detectors when the Tenant(s) moves into the Premises. After the initial placement of the fresh batteries, it is the responsibility of the Tenant(s) to replace batteries when needed. A monthly “cursory” inspection may be required for all fire extinguishers to make sure they are fully charged."
        ]
      },
      {
        "Header": "EARLY TERMINATION:",
        "Text": [
          "The Tenant(s) may be allowed to cancel this Agreement under the following conditions:",
          "The Tenant(s) must provide at least {agreement.terminationPeriod} days' notice and pay an early termination fee of {agreement.terminationFee} (US Dollars) which does not include the rent due for the notice period. During the notice period of 60 days the rent shall be paid in accordance with this Agreement."
        ]
      },
      {
        "Header": "PETS:",
        "Text": [
          "The Tenant(s) shall be allowed to have:",
          "{agreement.petsAllowed} on the Premises consisting of Birds, Cats, Dogs, Fish, Hamsters, Rabbits, with no other types of Pet(s) being allowed on the Premises or common areas, hereinafter known as the “Pet(s)”. The Tenant(s) shall be required to pay a pet fee in the amount of {agreement.petsFee} for all the Pet(s) which is refundable at the end of the Lease Term only if there is no damage to the Premises that is caused by the Pet(s). The Tenant(s) is responsible for all damage that any pet causes, regardless of ownership of said pet and agrees to restore the property to its original condition at their expense. There shall be no limit on the weight of the pet. pounds (Lb.)."
        ]
      },
      {
        "Header": "NOISE/WASTE:",
        "Text": [
          "The Tenant(s) agrees not to commit waste on the Premises, maintain, or permit to be maintained, a nuisance thereon, or use, or permit the Premises to be used, in an unlawful manner. The Tenant(s) further agrees to abide by any and all local, county, and State noise ordinances."
        ]
      },
      {
        "Header": "GUESTS:",
        "Text": [
          "There shall be no other persons living on the Premises other than the Tenant(s) and any Occupant(s). Guests of the Tenant(s) are allowed for periods not lasting for more than forty-eight hours unless otherwise approved by the Landlord."
        ]
      },
      {
        "Header": "SMOKING POLICY:",
        "Text": [
          "Smoking on the Premises is prohibited on the entire property, including individual units, common areas, every building and adjoining properties."
        ]
      },
      {
        "Header": "COMPLIANCE WITH LAW:",
        "Text": [
          "The Tenant(s) agrees that during the term of the Agreement, to promptly comply with any present and future laws, ordinances, orders, rules, regulations, and requirements of the Federal, State, County, City, and Municipal government or any of their departments, bureaus, boards, commissions and officials thereof with respect to the Premises, or the use or occupancy thereof, whether said compliance shall be ordered or directed to or against the Tenant(s), the Landlord, or both."
        ]
      },
      {
        "Header": "DEFAULT:",
        "Text": [
          "If the Tenant(s) fails to comply with any of the financial or material provisions of this Agreement, or of any present rules and regulations or any that may be hereafter prescribed by the Landlord, or materially fails to comply with any duties imposed on the Tenant(s) by statute or State laws, within the time period after delivery of written notice by the Landlord specifying the non-compliance and indicating the intention of the Landlord to terminate the Agreement by reason thereof, the Landlord may terminate this Agreement. If the Tenant(s) fails to pay rent when due and the default continues for the time-period specified in the written notice thereafter, the Landlord may, at their option, declare the entire balance (compiling all months applicable to this Agreement) of rent payable hereunder to be immediately due and payable and may exercise any and all rights and remedies available to the Landlord at law or in equity and may immediately terminate this Agreement.",
          "The Tenant(s) will be in default if: (a) Tenant(s) does not pay rent or other amounts that are owed in accordance with respective State laws; (b) Tenant(s), their guests, or the Occupant(s) violate this Agreement, rules, or fire, safety, health, or criminal laws, regardless of whether arrest or conviction occurs; (c) Tenant(s) abandons the Premises; (d) Tenant(s) gives incorrect or false information in the rental application; (e) Tenant(s), or any Occupant(s) is arrested, convicted, or given deferred adjudication for a criminal offense involving actual or potential physical harm to a person, or involving possession, manufacture, or delivery of a controlled substance, marijuana, or drug paraphernalia under state statute; (f) any illegal drugs or paraphernalia are found in the Premises or on the person of the Tenant(s), guests, or Occupant(s) while on the Premises and/or; (g) as otherwise allowed by law."
        ]
      },
      {
        "Header": "MULTIPLE TENANT(S) OR OCCUPANT(S):",
        "Text": [
          "Each individual that is considered a Tenant(s) is jointly and individually liable for all of this Agreement's obligations, including but not limited to rent monies. If any Tenant(s), guest, or Occupant(s) violates this Agreement, the Tenant(s) is considered to have violated this Agreement. Landlord’s requests and notices to the Tenant(s) or any of the Occupant(s) of legal age constitutes notice to the Tenant(s). Notices and requests from the Tenant(s) or any one of the Occupant(s) (including repair requests and entry permissions) constitutes notice from the Tenant(s). In eviction suits, the Tenant(s) is considered the agent of the Premise for the service of process."
        ]
      },
      {
        "Header": "DISPUTES:",
        "Text": [
          "If a dispute arises during or after the term of this Agreement between the Landlord and Tenant(s), they shall agree to hold negotiations amongst themselves, in “good faith”, before any litigation."
        ]
      },
      {
        "Header": "SEVERABILITY:",
        "Text": [
          "If any provision of this Agreement or the application thereof shall, for any reason and to any extent, be invalid or unenforceable, neither the remainder of this Agreement nor the application of the provision to other persons, entities or circumstances shall be affected thereby, but instead shall be enforced to the maximum extent permitted by law."
        ]
      },
      {
        "Header": "SURRENDER OF PREMISES:",
        "Text": [
          "The Tenant(s) has surrendered the Premises when (a) the moveout date has passed and no one is living in the Premise within the Landlord’s reasonable judgment; or (b) Access to the Premise have been turned in to Landlord – whichever comes first. Upon the expiration of the term hereof, the Tenant(s) shall surrender the Premise in better or equal condition as it were at the commencement of this Agreement, reasonable use, wear and tear thereof, and damages by the elements excepted."
        ]
      },
      {
        "Header": "RETALIATION:",
        "Text": [
          "The Landlord is prohibited from making any type of retaliatory acts against the Tenant(s) including but not limited to restricting access to the Premises, decreasing or cancelling services or utilities, failure to repair appliances or fixtures, or any other type of act that could be considered unjustified."
        ]
      },
      {
        "Header": "WAIVER:",
        "Text": [
          "A Waiver by the Landlord for a breach of any covenant or duty by the Tenant(s), under this Agreement is not a waiver for a breach of any other covenant or duty by the Tenant(s), or of any subsequent breach of the same covenant or duty. No provision of this Agreement shall be considered waived unless such a waiver shall be expressed in writing as a formal amendment to this Agreement and executed by the Tenant(s) and Landlord."
        ]
      },
      {
        "Header": "EQUAL HOUSING:",
        "Text": [
          "If the Tenant(s) possess(es) any mental or physical impairment, the Landlord shall provide reasonable modifications to the Premises unless the modifications would be too difficult or expensive for the Landlord to provide. Any impairment of the Tenant(s) is/are encouraged to be provided and presented to the Landlord in writing in order to seek the most appropriate route for providing the modifications to the Premises."
        ]
      },
      {
        "Header": "HAZARDOUS MATERIALS:",
        "Text": [
          "The Tenant(s) agrees to not possess any type of personal property that could be considered a fire hazard such as a substance having flammable or explosive characteristics on the Premises. Items that are prohibited to be brought into the Premises, other than for everyday cooking or the need of an appliance, includes but is not limited to gas (compressed), gasoline, fuel, propane, kerosene, motor oil, fireworks, or any other related content in the form of a liquid, solid, or gas."
        ]
      },
      {
        "Header": "WATERBEDS:",
        "Text": [
          "The Tenant(s) is not permitted to furnish the Premises with waterbeds."
        ]
      },
      {
        "Header": "INDEMNIFICATION:",
        "Text": [
          "The Landlord shall not be liable for any damage or injury to the Tenant(s), or any other person, or to any property, occurring on the Premises, or any part thereof, or in common areas thereof, and the Tenant(s) agrees to hold the Landlord harmless from any claims or damages unless caused solely by the Landlord's negligence. It is recommended that renter's insurance be purchased at the Tenant(s)'s expense."
        ]
      },
      {
        "Header": "COVENANTS:",
        "Text": [
          "The covenants and conditions herein contained shall apply to and bind the heirs, legal representatives, and assigns of the parties hereto, and all covenants are to be construed as conditions of this Agreement"
        ]
      },
      {
        "Header": "NOTICES:",
        "Text": [
          "Any notice to be sent by the Landlord or the Tenant(s) to each other shall use the following mailing addresses:"
        ]
      },
      {
        "Header": "Landlord's/Agent's Mailing Address",
        "Text": [
          "",
          "{landlord.name}, {landlord.nameExt}\n{landlord.mailAddress}"
        ]
      },
      {
        "Header": "Tenant(s)'s Mailing Address",
        "Text": [
          "",
          "{tenant.knownAs.asList}\n{tenant.mailAddress}"
        ]
      },
      {
        "Header": "AGENT/MANAGER:",
        "Text": [
          "The Landlord authorizes the following to act on their behalf in regards to the Premises for any repair, maintenance, or compliant other than a breach of this Agreement: The {manager.name} known as {manager.knownAs} of {manager.mailAddress} that can be contacted at the following Phone Number {manager.phone} and can be E-Mailed at {manager.emailAddress}."
        ]
      },
      {
        "Header": "PREMISES DEEMED UNINHABITABLE:",
        "Text": [
          "If the Property is deemed uninhabitable due to damage beyond reasonable repair the Tenant(s) will be able to terminate this Agreement by written notice to the Landlord. If said damage was due to the negligence of the Tenant(s), the Tenant(s) shall be liable to the Landlord for all repairs and for the loss of income due to restoring the Premises back to a livable condition in addition to any other losses that can be proved by the Landlord."
        ]
      },
      {
        "Header": "SERVICEMEMBERS CIVIL RELIEF ACT:",
        "Text": [
          "In the event the Tenant(s) is or hereafter becomes, a member of the United States Armed Forces on extended active duty and hereafter the Tenant(s) receives permanent change of station (PCS) orders to depart from the area where the Premises are located, or is relieved from active duty, retires or separates from the military, is ordered into military housing, or receives deployment orders, then in any of these events, the Tenant may terminate this lease upon giving {agreement.armedForcesNotice} written notice to the Landlord. The Tenant shall also provide to the Landlord a copy of the official orders or a letter signed by the Tenant’s commanding officer, reflecting the change which warrants termination under this clause. The Tenant will pay prorated rent for any days which he/she occupies the dwelling past the beginning of the rental period.",
          "The damage/security deposit will be promptly returned to Tenant, provided there are no damages to the Premises."
        ]
      },
      {
        "Header": "LEAD PAINT:",
        "Text": [
          "The Premises was not constructed before 1978 and therefore does not contain leadbased paint."
        ]
      },
      {
        "Header": "GOVERNING LAW:",
        "Text": [
          "This Agreement is to be governed under the laws located in the State of {agreement.lawsState}."
        ]
      },
      {
        "Header": "ADDITIONAL TERMS AND CONDITIONS:",
        "Text": [
          "In addition to the above stated terms and conditions of this Agreement, the Landlord and Tenant agree to the following: Additional Terms are to be specified: Term 1, Term 2, Term 3"
        ]
      },
      {
        "Header": "ENTIRE AGREEMENT:",
        "Text": [
          "This Agreement contains all the terms agreed to by the parties relating to its subject matter including any attachments or addendums. This Agreement replaces all previous discussions, understandings, and oral agreements. The Landlord and Tenant(s) agree to the terms and conditions and shall be bound until the end of the Lease Term.",
          "The parties have agreed and executed this agreement on {agreement.date}."
        ]
      } 
    ]
    ```

  * **Model/AgreementText.cs** file:

    ```
    namespace RentalAgreement.Model
    {
        public class AgreementText
        {
    
            public string Header { get; set; }
            public string[] Text { get; set; }
    
            public override string ToString() 
            {
                return  "AgreementText{" +  
                        "Header=" + Header +
                        ", Text=" + Text +
                         "}";
            }
        }
    }
    ```
    
  * **Content/ra-checklist.json** file:

    ```json
    [
      {
        "Name": "Living Room",
        "Items": [
            "Floors Condition",
            "Walls Condition",
            "Ceiling Condition",
            "Windows Condition",
            "Lighting Condition",
            "Electrical Outlets",
            "Other Condition",
            "Other Condition"
        ]
      },
      {
        "Name": "Dining Room",
        "Items": [
            "Floors Condition",
            "Walls Condition",
            "Ceiling Condition",
            "Windows Condition",
            "Lighting Condition",
            "Electrical Outlets",
            "Other Condition",
            "Other Condition"
        ]
      },
      {
        "Name": "Kitchen Area",
        "Items": [
            "Stove",
            "Refrigerator Condition",
            "Sink",
            "Floors Condition",
            "Walls Condition",
            "Ceiling Condition",
            "Windows Condition",
            "Lighting Condition",
            "Electrical Outlets",
            "Cabinets Condition",
            "Closets Condition",
            "Exhaust Fan",
            "Fire Alarms",
            "Other Condition",
            "Other Condition"
        ]
      },
      {
        "Name": "Bedroom(s)",
        "Items": [
            "Doors",
            "Closets Condition",
            "Floors Condition",
            "Walls Condition",
            "Ceiling Condition",
            "Windows Condition",
            "Lighting Condition",
            "Electrical Outlets",
            "Other Condition",
            "Other Condition"
        ]
      },
      {
        "Name": "Bathroom(s)",
        "Items": [
            "Sink",
            "Shower",
            "Curtain",
            "Towel Rack",
            "Toilet Condition",
            "Doors",
            "Floors Condition",
            "Walls Condition",
            "Ceiling Condition",
            "Windows Condition",
            "Lighting Condition",
            "Electrical Outlets",
            "Other Condition",
            "Other Condition"
        ]
      },
      {
        "Name": "Other",
        "Items": [
            "Heating Condition",
            "AC Unit",
            "Hot Water",
            "Smoke Alarm",
            "Door Bell",
            "Other Condition",
            "Other Condition"
        ]
      }
    ]
    ```

  * **Model/CheckList.cs** file:

    ```
    namespace RentalAgreement.Model
    {
        public class CheckList
        {
    
            public string Name { get; set; } = "";
            public string[] Items { get; set; } = { };
    
            public override string ToString() 
            {
                return "CheckList{" +  
                       "Name=" + Name +
                        ", Items=" + Items +
                       "}";
            }
        }
    }
    ```
    
  * **Content/ra-parties.json** file:

    ```json
    [
      {
        "Party": "Landlord",
        "KnownAs": "Landlord",
        "Name": "Best Landlord Company",
        "NameExt": "ATTN. John Landlord",
        "MailAddress": "2 Maple Ln, Suite A, Best Town, Alabama, 29227",
        "Signer": "John Landlord as President of Best Landlord Company"
      },  
      {
        "Party": "Tenant",
        "Name": "Alex Tenant",
        "KnownAs": "Alex Tenant",
        "MailAddress": "1 Main Street, Apt 4, Small Town, Alabama, 20992"
      },
      {
        "Party": "Tenant",
        "Name": "Joanna Tenant",
        "KnownAs": "Joanna Tenant"
      },
      {
        "Party": "TenantAdd",
        "Name": "Alex Jr Tenant",
        "KnownAs": "Alex Jr Tenant"
      },
      {
        "Party": "TenantAdd",
        "Name": "Jill Tenant",
        "KnownAs": "Jill Tenant"
      },
      {
        "Party": "Manager",
        "Name": "The management company",
        "KnownAs": "Best Management Company",
        "MailAddress": "5 Maple Ave, Suite 12A, Best City, Alabama, 29277",
        "Phone": "(888) 222-3333",
        "EmailAddress": "email@email.com"
      }
    ]
    ```
    
    * **Model/PartyData.cs** file:
  
      ```c#
      namespace RentalAgreement.Model
      {
          public class PartyData
          {
      
              public string Party { get; set; } = "";
              public string KnownAs { get; set; } = "";
              public string Name { get; set; } = "";
              public string NameExt { get; set; } = "";
              public string MailAddress { get; set; } = "";
              public string Phone { get; set; } = "";
              public string EmailAddress { get; set; } = "";
              public string Signer { get; set; } = "";
      
      
              public override string ToString() 
              {
                  return "AgreementText{" +  
                         "Party=" + Party +
                          ", KnownAs=" + KnownAs +
                          ", Name=" + Name +
                          ", NameExt=" + NameExt +
                          ", MailAddress=" + MailAddress +
                          ", Phone=" + Phone +
                          ", EmailAddress=" + EmailAddress +
                          ", Signer=" + EmailAddress +
                         "}";
              }
          }
      }
      ```

## 5. The Program class

Responsibility:

* Parse command line options.
  You can process the command line options using the `PrepareParameters` that prepares the `Parameters` structure.
* Display prompts to the user when one of the following options is present in the command line: `“?”`, `“-h”`, `“-help”`, `“--h”`, `“--help”`. It is processed by `Usage`.
* Build the document. It delegates the document building to the `RentalAgreementRunner` class with the name of the resulting document file.
* Run the application to demonstrate the resulting document if specified in the command line options.

## 6. The RentalAgreementRunner class

Responsibility:

* Create an object of the `RentalAgreementBuilder` class.

* Initialize its properties with data of Rental Agreement. The properties of the `RentalAgreementBuilder` class have the default values, which are located in the several json files.

  ```c#
  using System.Collections.Generic;
  using System.IO;
  using RentalAgreement.Model;
  using Gehtsoft.PDFFlow.Builder;
  using Newtonsoft.Json;
  
  namespace RentalAgreement
  {
      public static class RentalAgreementRunner
      {
          public static DocumentBuilder Run()
          {
              string agreementTextJsonFile = CheckFile(
                  Path.Combine("Content", "ra-agreement-text.json"));
              string agreementJsonFile = CheckFile(
                  Path.Combine("Content", "ra-agreement.json"));
              string partiesJsonFile = CheckFile(
                  Path.Combine("Content", "ra-parties.json"));
              string checklistJsonFile = CheckFile(
                  Path.Combine("Content", "ra-checklist.json"));
  
              string agreementTextJsonContent = 
                  File.ReadAllText(agreementTextJsonFile);
              string agreementJsonContent = 
                  File.ReadAllText(agreementJsonFile);
              string partiesJsonContent =
                  File.ReadAllText(partiesJsonFile);
              string checklistJsonContent =
                  File.ReadAllText(checklistJsonFile);
  
              List<AgreementText> agreementText =
                  JsonConvert.DeserializeObject<List<AgreementText>>(
                      agreementTextJsonContent);
              AgreementData agreement =
                  JsonConvert.DeserializeObject<AgreementData>(
                      agreementJsonContent);
              List<PartyData> partyData = 
                  JsonConvert.DeserializeObject<List<PartyData>>(
                      partiesJsonContent);
              List<CheckList> checkList = 
                  JsonConvert.DeserializeObject<List<CheckList>>(
                      checklistJsonContent);
  
              var rentalAgreementBuilder =
                  new RentalAgreementBuilder();
  
              rentalAgreementBuilder.AgreementText = agreementText;
              rentalAgreementBuilder.Agreement = agreement;
              rentalAgreementBuilder.PartyData = partyData;
              rentalAgreementBuilder.CheckList = checkList;
  
              return rentalAgreementBuilder.Build();
          }
  
          private static string CheckFile(string file)
          {
              if (!File.Exists(file))
              {
                  throw new IOException("File not found: " + 
                      Path.GetFullPath(file));
              }
              return file;
          }
      }
  }
  ```

These lines are not required to run the sample application. 
But these lines and subsequent lines must contain real information about the rental entity and data.

* Build the document. It delegates the document building to the `RentalAgreementBuilder` class using the `DocumentBuilder` method.

## 7. The RentalAgreementBuilder class

Responsibility:

* Save the properties with data.

The method `DocumentBuilder` has the following responsibilities:

* Create an object of the `Gehtsoft.PDFFlow.Builder.DocumentBuilder` class.
* Create an object of the `rentalAgreementTextBuilder` class and build the lease page s using the `Build` method of the created object.
* Create an object of the `rentalAgreementDepositBuilder` class and build the deposit page using the `Build` method of the created object.
* Create an object of the `rentalAgreementAmountBuilder` class and build the amount page using the `Build` method of the created object
* Create an object of the `rentalAgreementCheckListBuilder` class and build the checklist pages using the `Build` method of the created object
* Return the created object of the `Gehtsoft.PDFFlow.Builder.DocumentBuilder` class.

## 8. The RentalAgreementTextBuilder class

Responsibility:

* Create a page and set its parameters:

```csharp
internal static readonly Box Margins = new Box(25, 16, 60, 16);
internal static readonly XUnit PageWidth =
    (PredefinedSizeBuilder.ToSize(PaperSize.Letter).Width -
        (Margins.Left + Margins.Right));

internal static readonly XUnit PageHeight =
    (PredefinedSizeBuilder.ToSize(PaperSize.Letter).Height -
        (Margins.Top + Margins.Bottom));


	internal void Build(DocumentBuilder documentBuilder)
        {
            var sectionBuilder = documentBuilder.AddSection();
            sectionBuilder
                .SetOrientation(Orientation)
                .SetMargins(Margins);
            sectionBuilder.SetRepeatingAreaPriority(
                RepeatingAreaPriority.Vertical);
        }         
```

* Implement data: 

```csharp
        private PartyData landlord = new PartyData();
        private PartyData manager = new PartyData();
        private List<PartyData> tenant = new List<PartyData>();
        private List<PartyData> tenantAdd = new List<PartyData>();
        private AgreementData agreement;

        internal Dictionary<string, string> dict;
        private List<AgreementText> agreementText;

        internal RentalAgreementTextBuilder SetLandord(PartyData landlord)
        {
            this.landlord = landlord;
            return this;
        }

        internal RentalAgreementTextBuilder SetManager(PartyData manager)
        {
            this.manager = manager;
            return this;
        }

        internal RentalAgreementTextBuilder SetTenant(List<PartyData> tenant)
        {
            this.tenant = tenant;
            return this;
        }

        internal RentalAgreementTextBuilder SetTenantAdd(
            List<PartyData> tenantAdd)
        {
            this.tenantAdd = tenantAdd;
            return this;
        }

        internal RentalAgreementTextBuilder SetAgreement(
            AgreementData agreement)
        {
            this.agreement = agreement;
            return this;
        }

        internal RentalAgreementTextBuilder SetAgreementText(
            List<AgreementText> agreementText)
        {
            this.agreementText = agreementText;
            return this;
        }
```

* Create the nine pages of the document.
  This is done by the `Build` method. It creates objects one by one and runs the following methods:


* `BuidHeader`
* `BuildFooterBar`
* `BuildEqualHousingOpportunity`
* `BuildTextsPages`
*  `BuildSignatures`

```csharp
        internal void Build(DocumentBuilder documentBuilder)
        {
            var sectionBuilder = documentBuilder.AddSection();
            sectionBuilder
                .SetOrientation(Orientation)
                .SetMargins(Margins);
            sectionBuilder.SetRepeatingAreaPriority(
                RepeatingAreaPriority.Vertical);
            BuildHeader(
                sectionBuilder.AddHeaderToBothPages(80), PageWidth);
            BuildFooterBar(sectionBuilder.AddFooterToBothPages(90), 86);
            BuildEqualHousingOpportunity(
                sectionBuilder.AddRptAreaLeftToBothPages(65), PageHeight);
            sectionBuilder
                .AddParagraph(MAIN_TITLE)
                .SetAlignment(HorizontalAlignment.Center)
                .SetFont(MAIN_TITLE_FONT)
                .SetMarginBottom(MAIN_TITLE_BOTTOM_MARGIN);
            BuildTextsPages(sectionBuilder);
            BuildSignatures(sectionBuilder, GetSignData());
        }
```

Repeating headers and  footers is created by the `BuildHeader` and `BuildFooterBar` methods. They are in `rentalAgreementHelper` class.

## 9. The RentalAgreementHelper class

Responsibility:

* Create header and footer:

  ```c#
  	internal static void BuildHeaderWithBar(RepeatingAreaBuilder builder, 
          float pageWidth)
      {
          var tableBuilder = builder.AddTable();
          tableBuilder
              .SetBorder(Stroke.None)
              .SetWidth(XUnit.FromPercent(100))
              .AddColumnPercentToTable("", 50)
              .AddColumnPercentToTable("", 50);
          var rowBuilder = tableBuilder.AddRow();
          rowBuilder.AddCell()
              .AddImage(Path.Combine("images", "ra-logo-2x.png"),
                  XSize.FromHeight(120));
          rowBuilder.AddCell()
              .SetHorizontalAlignment(HorizontalAlignment.Right)
              .AddImage(Path.Combine("images", "ra-barcode.png"),
                  XSize.FromHeight(120));
          builder.AddParagraph()
              .SetAlignment(HorizontalAlignment.Right)
              .SetUrlStyle(
                  StyleBuilder.New()
                      .SetFont(URL_FONT))
              .AddUrlToParagraph("http://www.bestlandlords.com/billing");
          builder.AddLine(pageWidth, 1.5f, Stroke.Solid, Color.Gray)
              .SetMarginTop(5);
  
      }
  
      internal static void BuildHeader(RepeatingAreaBuilder builder, 
          float pageWidth)
      {
          builder
              .AddImage(Path.Combine("images", "ra-logo-2x.png"),
                  XSize.FromHeight(60));
          builder.AddLine(pageWidth, 1.5f, Stroke.Solid, Color.Gray)
              .SetMarginTop(5);
  
      }
  
      internal static void BuildFooterEqualHousingOpportunity(
          RepeatingAreaBuilder builder)
      {
          builder
              .AddImage(Path.Combine("images",
                          "equal-housing-opportunity-logo-1200w.png"),
                  XSize.FromHeight(80))
              .SetAlignment(HorizontalAlignment.Left);
          BuildFooter(builder);
      }
  
      internal static void BuildFooterBar(RepeatingAreaBuilder builder, float barImageHeight)
      {
          var tableBuilder = builder.AddTable();
          tableBuilder
              .SetBorder(Stroke.None)
              .SetWidth(XUnit.FromPercent(100))
              .AddColumnPercentToTable("", 40)
              .AddColumnPercentToTable("", 42)
              .AddColumnPercentToTable("", 10)
              .AddColumnPercentToTable("", 8);
          var rowBuilder = tableBuilder.AddRow();
          rowBuilder.SetVerticalAlignment(VerticalAlignment.Bottom);
          rowBuilder.AddCell()
              .SetPadding(40, 0, 0, 0)
              .SetFont(FNT11)
              .SetHorizontalAlignment(HorizontalAlignment.Right)
              .AddParagraph()
              .SetAlignment(HorizontalAlignment.Left)
              .AddTextToParagraph("Initials ", INITALS_FONT,
                  true)
              .AddTabulation(140, TabulationType.Left,
                  TabulationLeading.BottomLine);
          rowBuilder
              .AddCell()
              .SetHorizontalAlignment(HorizontalAlignment.Right)
              .SetPadding(0, 0, 5, 0)
              .AddParagraph()
              .SetUrlStyle(
                  StyleBuilder.New()
                      .SetFontColor(Color.Red)
                      .SetFont(URL_FONT))
              .AddUrlToParagraph("http://www.bestlandlords.com/billing");
          rowBuilder
              .AddCell()
              .AddImage(Path.Combine("images", "ra-barcode.png"),
                  XSize.FromHeight(barImageHeight));
          rowBuilder.AddCell().AddParagraph()
              .SetAlignment(HorizontalAlignment.Right)
              .AddTextToParagraph(" ", PAGE_NUMBER_FONT, true)
              .AddTextToParagraph("Page ", PAGE_NUMBER_FONT)
              .AddPageNumber().SetFont(PAGE_NUMBER_FONT);
      }
  
      internal static void BuildFooter(RepeatingAreaBuilder builder)
      {
          ParagraphBuilder paragraphBuilder = builder
              .AddParagraph();
          paragraphBuilder
              .SetAlignment(HorizontalAlignment.Right)
              .AddTextToParagraph(" ", PAGE_NUMBER_FONT, true)
              .AddTextToParagraph("Page ", PAGE_NUMBER_FONT)
              .AddPageNumber().SetFont(PAGE_NUMBER_FONT);
      }
  
      internal static void BuildEqualHousingOpportunity(RepeatingAreaBuilder builder,
          float pageHeight)
      {
          builder
              .AddImage(Path.Combine("images",
                  "equal-housing-opportunity-logo-160w.png"),
                  XSize.FromHeight(64))
                  .SetMarginTop(pageHeight - 66f);
      }
  ```

* Sets data format:

  ```c#
      internal static string DateToString(DateTime date)
      {
          return date.ToString(
                      "MMMM dd yyyy", DocumentLocale);
      }
  
      internal static string FundToString(double fund)
      {
          return "$" + String.Format(
              DocumentLocale, "{0:0,0.00}", fund);
      }
  
      internal static string PercentsToString(double procents)
      {
          if (procents < 10)
          {
              return
                  String.Format(DocumentLocale, "{0:,0.00}", procents) 
                      + "%";
          }
          return String.Format(DocumentLocale, "{0:0,0.00}", procents) 
                  + "%";
      }
  ```

Responsibility:

* Create a form of the Security Deposit Receipt.

Set page properties:

```c#
internal class RentalAgreementDepositBuilder
{
    internal static readonly Box Margins = new Box(60, 16, 60, 16);
    internal static readonly XUnit PageWidth =
        (PredefinedSizeBuilder.ToSize(PaperSize.Letter).Width -
            (Margins.Left + Margins.Right));

    internal static readonly XUnit PageHeight =
        (PredefinedSizeBuilder.ToSize(PaperSize.Letter).Height -
            (Margins.Top + Margins.Bottom));
 }
```

The form is constructed by the `Build` method.

```csharp
        internal void Build(DocumentBuilder documentBuilder)
        {
            var sectionBuilder = documentBuilder
                .AddSection()
                .SetOrientation(Orientation)
                .SetMargins(Margins);
            //sectionBuilder.SetRepeatingAreaPriority(RepeatingAreaPriority.Vertical);
            BuildHeader(sectionBuilder.AddHeaderToBothPages(140), PageWidth);
            BuildFooter(sectionBuilder.AddFooterToBothPages(40));
            //BuildFooterQqualHousingOpportunity(sectionBuilder.AddFooterToBothPages(85));
            //BuildQqualHousingOpportunity(sectionBuilder.AddRptAreaLeftToBothPages(85));
            var paragraphBuilder = sectionBuilder.AddParagraph();
            paragraphBuilder.SetFont(MAIN_TITLE_FONT)
                .SetAlignment(HorizontalAlignment.Center)
                .SetMarginBottom(MAIN_TITLE_BOTTOM_MARGIN)
                .AddText("Security Deposit Receipt");
            paragraphBuilder = sectionBuilder.AddParagraph();
            paragraphBuilder
                .SetMarginBottom(PARAGRAPH_BOTTOM_MARGIN)
                .AddTextToParagraph("Date:", TEXT_FONT, true)
                .AddTabulation(150, TabulationType.Left,
                    TabulationLeading.BottomLine);
            paragraphBuilder = sectionBuilder.AddParagraph();
            paragraphBuilder
                .SetMarginBottom(PARAGRAPH_BOTTOM_MARGIN)
                .AddTextToParagraph("Dear", TEXT_FONT, true)
                .AddTabulation(150, TabulationType.Left,
                    TabulationLeading.BottomLine)
                .AddTextToParagraph("[Tenant(s)],", TEXT_FONT, true);
            paragraphBuilder = sectionBuilder.AddParagraph();
            paragraphBuilder
                .SetFont(TEXT_FONT)
                .SetMarginTop(PARAGRAPH_TOP_MARGIN)
                .SetMarginBottom(PARAGRAPH_BOTTOM_MARGIN)
                .AddTextToParagraph(
                    "The Landlord shall hold the Security Deposit in a separate account at a bank"
                 );
            paragraphBuilder = sectionBuilder.AddParagraph();
            paragraphBuilder
                .SetMarginBottom(PARAGRAPH_BOTTOM_MARGIN)
                .AddTextToParagraph("located at", TEXT_FONT, true)
                .AddTabulation(280, TabulationType.Left,
                    TabulationLeading.BottomLine)
                .AddTextToParagraph(" [Street Address] in", TEXT_FONT, true);
            paragraphBuilder = sectionBuilder.AddParagraph();
            paragraphBuilder
                .SetMarginBottom(PARAGRAPH_BOTTOM_MARGIN)
                .AddTextToParagraph("the City of", TEXT_FONT, true)
                .AddTabulation(200, TabulationType.Left,
                    TabulationLeading.BottomLine)
                .AddTabulation(375, TabulationType.Left,
                    TabulationLeading.BottomLine)
                .AddTextToParagraph(", State of", TEXT_FONT, true)
                .AddTextToParagraph(".");
            paragraphBuilder = sectionBuilder.AddParagraph();
            paragraphBuilder
                .SetMarginBottom(PARAGRAPH_ROW_DIST)
                .AddTextToParagraph(
                    "The Security Deposit in the amount of $", TEXT_FONT, 
                     true)
                .AddTabulation(300, TabulationType.Left,
                    TabulationLeading.BottomLine)
                .AddTextToParagraph(
                    " (US Dollars) has been deposited in", TEXT_FONT, true);
            paragraphBuilder = sectionBuilder.AddParagraph();
            paragraphBuilder
                .SetMarginBottom(PARAGRAPH_ROW_DIST)
                .AddTextToParagraph(" ", TEXT_FONT, true)
                .AddTabulation(120, TabulationType.Left,
                    TabulationLeading.BottomLine)
                .AddTabulation(434, TabulationType.Left,
                    TabulationLeading.BottomLine)
                .AddTextToParagraph(
                    "[Bank Name] with the Account Number of", TEXT_FONT, true)
                .AddTextToParagraph(" for the full");
            paragraphBuilder = sectionBuilder.AddParagraph();
            paragraphBuilder
                .SetMarginBottom(PARAGRAPH_BOTTOM_MARGIN)
                .AddTextToParagraph(
                    "performance of the Lease executed on the ", TEXT_FONT, 
                    true)
                .AddTabulation(220, TabulationType.Left,
                    TabulationLeading.BottomLine)
                .AddTextToParagraph(" day of ", TEXT_FONT, true)
                .AddTabulation(400, TabulationType.Left,
                    TabulationLeading.BottomLine)
                .AddTextToParagraph(", 20", TEXT_FONT, true)
                .AddTabulation(434, TabulationType.Left,
                    TabulationLeading.BottomLine)
                .AddTextToParagraph(".");
            paragraphBuilder = sectionBuilder.AddParagraph();
            paragraphBuilder
                .SetMarginBottom(PARAGRAPH_BOTTOM_MARGIN)
                .SetFont(TEXT_FONT)
                .AddTextToParagraph("Sincerely,");
            paragraphBuilder = sectionBuilder.AddParagraph();
            paragraphBuilder
                .SetMarginBottom(PARAGRAPH_BOTTOM_MARGIN)
                .AddTextToParagraph("Landlord’s Signature ", HEADER_FONT, 
                    true)
                .AddTabulation(250, TabulationType.Left,
                    TabulationLeading.BottomLine);
        }
```

## 10. The RentalAgreementAmountBuilder class

Responsibility:

* Creates the AMOUNT ($) DUE AT SIGNING page.

Set page properties:

```c#
internal class RentalAgreementAmountBuilder
    {
        private const float MAIN_TITLE_BOTTOM_MARGIN = 40;
        internal static readonly Box Margins = new Box(60, 16, 60, 16);
        internal static readonly XUnit PageWidth =
            (PredefinedSizeBuilder.ToSize(PaperSize.Letter).Width -
                (Margins.Left + Margins.Right));

        internal static readonly XUnit PageHeight =
            (PredefinedSizeBuilder.ToSize(PaperSize.Letter).Height -
                (Margins.Top + Margins.Bottom));

        private AgreementData agreement;
}
```

Construct a form by the `Build` method.

```c#
        internal void Build(DocumentBuilder documentBuilder)
        {
            var sectionBuilder = documentBuilder
                .AddSection()
                .SetOrientation(Orientation)
                .SetMargins(Margins);
            //sectionBuilder.SetRepeatingAreaPriority(RepeatingAreaPriority.Vertical);
            BuildHeader(sectionBuilder.AddHeaderToBothPages(140), PageWidth);
            BuildFooter(sectionBuilder.AddFooterToBothPages(40));
            //BuildFooterQqualHousingOpportunity(sectionBuilder.AddFooterToBothPages(85));
            //BuildQqualHousingOpportunity(sectionBuilder.AddRptAreaLeftToBothPages(85));
            sectionBuilder.AddParagraph()
                .SetAlignment(HorizontalAlignment.Center)
                .SetMarginBottom(MAIN_TITLE_BOTTOM_MARGIN)
                .AddText("AMOUNT ($) DUE AT SIGNING");
            sectionBuilder.AddParagraph()
                .SetMarginBottom(PARAGRAPH_BOTTOM_MARGIN)
                .AddTextToParagraph("Security Deposit: ", HEADER_FONT)
                .AddTextToParagraph(FundToString(agreement.SecurityDeposit), 
                    TEXT_FONT);
            sectionBuilder.AddParagraph()
                .SetMarginBottom(PARAGRAPH_BOTTOM_MARGIN)
                .AddTextToParagraph("First (1st) Month's Rent: ", HEADER_FONT)
                .AddTextToParagraph(FundToString(agreement.MonthPayment), 
                    TEXT_FONT);
            sectionBuilder.AddParagraph()
                .SetMarginBottom(PARAGRAPH_BOTTOM_MARGIN)
                .AddTextToParagraph("Pet Fee(s): ", HEADER_FONT)
                .AddTextToParagraph(FundToString(agreement.PetsFee), 
                    TEXT_FONT)
                .AddTextToParagraph(" for all the Pet(s)", TEXT_FONT);
        }
```

## 11. The **RentalAgreementCheckList**Builder class

Responsibility: 

* Create three Move-in checklist pages.

Set page properties:

```c#
    internal class RentalAgreementCheckListBuilder
    {

        private const float MAIN_TITLE_BOTTOM_MARGIN = 10;
        const float RAGRAPH_BOTTOM_MARGIN = 16;
        const float ROW_BOTTOM_MARGIN = 1;

        internal static readonly Box Margins = new Box(60, 16, 60, 16);
        internal static readonly XUnit PageWidth =
            (PredefinedSizeBuilder.ToSize(PaperSize.Letter).Width -
                (Margins.Left + Margins.Right));

        internal static readonly XUnit PageHeight =
            (PredefinedSizeBuilder.ToSize(PaperSize.Letter).Height -
                (Margins.Top + Margins.Bottom));
	}
```

Configure the data:

```c#
    private AgreementData agreement;
    private List<CheckList> checkList;

    internal RentalAgreementCheckListBuilder SetAgreement(
        AgreementData agreement)
    {
        this.agreement = agreement;
        return this;
    }

    internal RentalAgreementCheckListBuilder SetCheckList(
        List<CheckList> checkList)
    {
        this.checkList = checkList;
        return this;
    }
```
Construct a form by the `Build` method.

```c#
        internal void Build(DocumentBuilder documentBuilder)
        {
            var sectionBuilder = documentBuilder
                .AddSection()
                .SetOrientation(Orientation)
                .SetMargins(Margins);
            //sectionBuilder.SetRepeatingAreaPriority(RepeatingAreaPriority.Vertical);
            BuildHeader(sectionBuilder.AddHeaderToBothPages(140), PageWidth);
            BuildFooter(sectionBuilder.AddFooterToBothPages(40));
            //BuildFooterQqualHousingOpportunity(sectionBuilder.AddFooterToBothPages(85));
            //BuildQqualHousingOpportunity(sectionBuilder.AddRptAreaLeftToBothPages(85));
            sectionBuilder.AddParagraph()
                .SetAlignment(HorizontalAlignment.Center)
                .SetMarginBottom(MAIN_TITLE_BOTTOM_MARGIN)
                .AddText("AMOUNT ($) DUE AT SIGNING");
            sectionBuilder.AddParagraph()
                .SetMarginBottom(PARAGRAPH_BOTTOM_MARGIN)
                .AddTextToParagraph("Security Deposit: ", HEADER_FONT)
                .AddTextToParagraph(FundToString(agreement.SecurityDeposit), 
                    TEXT_FONT);
            sectionBuilder.AddParagraph()
                .SetMarginBottom(PARAGRAPH_BOTTOM_MARGIN)
                .AddTextToParagraph("First (1st) Month's Rent: ", HEADER_FONT)
                .AddTextToParagraph(FundToString(agreement.MonthPayment), 
                    TEXT_FONT);
            sectionBuilder.AddParagraph()
                .SetMarginBottom(PARAGRAPH_BOTTOM_MARGIN)
                .AddTextToParagraph("Pet Fee(s): ", HEADER_FONT)
                .AddTextToParagraph(FundToString(agreement.PetsFee), 
                    TEXT_FONT)
                .AddTextToParagraph(" for all the Pet(s)", TEXT_FONT);
        }
```

## 