import 'package:flutter/material.dart';
import 'package:passenger_app/NavBar.dart';
import 'package:passenger_app/constants.dart';

class ContactUs extends StatelessWidget {
  static var formKey = GlobalKey<FormState>();
  var nameController = TextEditingController();
  var emailController = TextEditingController();
  var phoneController = TextEditingController();
  var messageController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: darkGreen,
      drawer: NavDrawer(),
      appBar: AppBar(
        iconTheme: IconThemeData(color: Colors.white),
        title: Text(
          'Contact us',
          style:
              TextStyle(fontSize: 22, fontFamily: 'Lato', color: Colors.white),
        ),
        centerTitle: true,
        backgroundColor: darkGreen,
      ),
      body: Container(
        height: MediaQuery.of(context).size.height,
        width: double.infinity,
        padding: const EdgeInsets.only(
          top: 20,
        ),
        decoration: const BoxDecoration(
          color: Colors.white,
          borderRadius: BorderRadius.only(
            topLeft: Radius.circular(20),
            topRight: Radius.circular(20),
          ),
        ),
        child: SingleChildScrollView(
          child: Padding(
            padding: const EdgeInsets.only(
              // top: 20,
              left: 20,
              right: 20,
            ),
            child: Form(
              key: formKey,
              child: Column(
                children: [
                  Text(
                    'Contact us by sending your message ,    we will reply to you soon',
                    textAlign: TextAlign.center,
                    style: TextStyle(
                        fontWeight: FontWeight.bold,
                        fontSize: 16,
                        fontFamily: 'Lato',
                        color: darkGreen),
                  ),
                  SizedBox(
                    height: 15,
                  ),
                  defaultFormFeild(
                    controller: nameController,
                    type: TextInputType.name,
                    label: 'Name',
                  ),
                  SizedBox(
                    height: 12,
                  ),
                  defaultFormFeild(
                    controller: emailController,
                    type: TextInputType.emailAddress,
                    label: 'Email',
                  ),
                  SizedBox(
                    height: 12,
                  ),
                  defaultFormFeild(
                    controller: phoneController,
                    type: TextInputType.number,
                    label: 'Phone',
                  ),
                  SizedBox(
                    height: 12,
                  ),
                  defaultFormFeild(
                    controller: messageController,
                    type: TextInputType.multiline,
                    min: 8,
                    max: 12,
                    label: 'Message',
                  ),
                  SizedBox(
                    height: 30,
                  ),
                  ElevatedButton(
                    style: ElevatedButton.styleFrom(
                      shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(20),
                      ),
                      minimumSize: const Size(400, 55),
                      primary: darkGreen,
                    ),
                    onPressed: () {
                      if (formKey.currentState!.validate()) {
                        emailController.text;
                        nameController.text;
                        phoneController.text;
                        messageController.text;
                      }
                    },
                    child: Text(
                      'Submit',
                      style: TextStyle(fontSize: 20, color: Colors.white),
                    ),
                  ),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }
}
