let connection = null;

setupConnection = () => {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("/zonorhub")
        .build();

    connection.on("NewDonation", function (donation) {
        console.info("Amount.." + donation.amount);
        console.info("DonationDate.." + donation.donationDate);
        console.info("DonationDate.." + donation.donor.name);
        var node = document.createElement("li");
        node.appendChild(document.createTextNode(donation.donor.name + " "));
        node.appendChild(document.createTextNode("$" + Number(donation.amount).toFixed(2) + " "));
        node.appendChild(document.createTextNode(donation.whenDonated));
        document.getElementById("donationList").appendChild(node);
    });

    connection.on("NewFundraiser", function (fundraiser) {
        console.info("name.." + fundraiser.name);
        var node = document.createElement("div");
        console.info("type: " + typeof fundraiser.createdDate);
        let creationDate = new Date(fundraiser.createdDate).toLocaleDateString("en-US");
        node.innerHTML = `<div class="col-sm-10 col-lg-10 col-md-10">
                            <div class="card">
                                <h4>
                                    <a href="/Fundraiser/Detail/${fundraiser.id}">${fundraiser.name}</a>
                                </h4>
                                <h4>$${fundraiser.currentTotal} raised of $${fundraiser.amount} goal</h4>
                                <h5>Created on ${creationDate}</h5>
                            </div >
                          </div>`;
        
        document.getElementById("fundraisersDiv").appendChild(node);

    });

    connection.on("finished", function () {
        connection.stop();          
    });

    connection.start()
        .catch(err => console.error(err.toString()));
}
setupConnection();