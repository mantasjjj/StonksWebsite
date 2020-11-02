<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StonksWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
      <!-- ======= Hero Section ======= -->
      <section id="hero">
        <div class="container position-relative text-mid" data-aos="fade-up">
          <h1>Welcome to Stonks!</h1>
          <h2>A World Class Smart Saver Web Application.</h2>
          <a href="#about" class="btn-get-started">Learn more about us</a>
        </div>
      </section><!-- End Hero -->

      <main id="main">

    <!-- ======= About Section ======= -->
    <section id="about" class="about">
      <div class="container">

        <div class="row">
          
        </div>

      </div>
    </section><!-- End About Section -->

    <!-- ======= Why Us Section ======= -->
    <section id="why-us" class="why-us">
      <div class="container">

        <div class="row">

          <div class="col-lg-4" data-aos="fade-up">
            <div class="box">
              <span>01</span>
              <h4>Savings Plan</h4>
              <p>Create you very own savings plan or choose a premade one.</p>
            </div>
          </div>

          <div class="col-lg-4 mt-4 mt-lg-0" data-aos="fade-up" data-aos-delay="150">
            <div class="box">
              <span>02</span>
              <h4>Your Finances</h4>
              <p>Update and track your income and expenses.</p>
            </div>
          </div>

          <div class="col-lg-4 mt-4 mt-lg-0" data-aos="fade-up" data-aos-delay="300">
            <div class="box">
              <span>03</span>
              <h4>Track Your Progress</h4>
              <p>Track your monthly or yearly progress displayed in different types of charts.</p>
            </div>
          </div>

        </div>

      </div>
    </section><!-- End Why Us Section -->

  </main><!-- End #main -->
</asp:Content>
