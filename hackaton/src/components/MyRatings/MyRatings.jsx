import React from 'react';

const MyRatings = () => {

  async function addReview(){

    const getCookie = (name) => {
      const cookieName = name + "=";
      const decodedCookie = decodeURIComponent(document.cookie);
      const cookieArray = decodedCookie.split(';');
      for (let i = 0; i < cookieArray.length; i++) {
        let cookie = cookieArray[i];
        while (cookie.charAt(0) === ' ') {
          cookie = cookie.substring(1);
        }
        if (cookie.indexOf(cookieName) === 0) {
          return cookie.substring(cookieName.length, cookie.length);
        }
      }
      return "";
    };

    const rating = document.getElementById("rating").value;
    const comment = document.getElementById("comment").value;
    const event = document.getElementById("event").value;
    const username = getCookie("loggedUser");

    const data =  {
      rating: rating,
      comment: comment
    }

    const request = {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json' 
    },
      body: JSON.stringify(data)
    }

    const response = await fetch(`https://localhost:7264/api/Simple/add-rating?userName=${username}&eventName=${event}`, request);

    const data1 = await response.json();

    if(data1.message === "You created a new Rating for this Event."){
      alert("Review added!");

      window.location.href = "/myratings";
    }
  }

  return (
    <>
      <div className="login-container">
      <div className="login-form">
        <label id="title">Add Review</label>
        <hr />
        <label htmlFor='event'>
              Activity: <br/><input id="event" type='text' name='event' placeholder="Enter activity" required/>
          </label>
          <br/>
        <label htmlFor='rating'>
              Rating: <br/><input id="rating" type='text' name='rating' placeholder="Enter your rating" required/>
          </label>
          <br/>
          <label htmlFor="comment">
            Comment: <br/><input id="comment" type='text' name="comment" placeholder="Enter your comment" required></input>
          </label>
          <br/>
          <button type="submit" className="btn" style={{backgroundColor: '#b5c99a', marginTop: "5%"}} onClick={addReview}>Submit</button>
        </div>
      </div>  
    </>
  )
}

export default MyRatings
