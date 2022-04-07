For this homework I had to imagine a few user stories that would exist in a software project. I came up with some examples for a music streaming platform that also offers its users custom recommendations.

<table>
  <tr>
    <td>
        As a logged-in user  </br> 
        I want to be able to search for music </br> 
        So that I can listen to it
    </td>
    <td>
        Scenario: User searches the databases with songs</br> 
        <b>Given</b> I’m a logged-in user and I’m on the Search page</br> 
        <b>When</b> I fill in the song I want to look for and I click on the button </br> 
        <b>Then</b> I receive the found results
    </td>
  </tr>
  <tr>
    <td>
        As a logged-in user </br> 
        I want to be able to save a song to my favorites playlist </br>
        So that I can listen to that song when searching the playlist
    </td>
    <td>
        Scenario: User adds song to favorties playlist </br>
        <b>Given</b> I’m a logged-in user and context provides me with access to the song </br> 
        <b>When</b> I add the song to the default playlist by clicking on plus button </br>
        <b>Then</b> I receive notification that my playlist was updated
    </td>
  </tr>
    <tr>
    <td>
        As a logged-in user  </br> 
        I want to be able to give feedback to song </br> 
        So that I can receive recommendations accordingly
    </td>
    <td>
        Scenario: User sends like/dislike feedback about a song </br> 
        <b>Given</b> I’m a logged-in user and context provides me with access to the song </br> 
        <b>When</b> I choose from options the desired feedback I want to send </br> 
        <b>Then</b> I receive notification
    </td>
  </tr>
    <tr>
    <td>
        As an offline user </br> 
        I want to be able to search to saved songs on my device </br> 
        So that I can be able to listen without connecting to a network
    </td>
    <td>
        Scenario: User searches the saved songs that are on personal device</br> 
        <b>Given</b> I’m an offline user and I’m on the Search page </br> 
        <b>When</b> I fill in the song I want to look for and I click on the button </br> 
        <b>Then</b> I receive the found results that I downloaded before
    </td>
  </tr>
</table>
