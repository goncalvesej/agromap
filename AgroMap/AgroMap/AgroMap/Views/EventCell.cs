﻿using AgroMap.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AgroMap.Views
{
    class EventCell : ViewCell
    {
        public EventCell(EventListScreen page)
        {

            //Inicializando componentes
            StackLayout mainLayout = new StackLayout();
            StackLayout firstLine = new StackLayout();
            StackLayout secondLine = new StackLayout();
            StackLayout thirdLine = new StackLayout();
            StackLayout fourthLine = new StackLayout();
            Label lblID = new Label();
            Label lblIDContent = new Label();
            Label lblUser = new Label();
            Label lblUserContent = new Label();
            Label lblType = new Label();
            Label lblTypeContent = new Label();
            Label lblLastEditAt = new Label();
            Label lblLastEditAtContent = new Label();


            //Atribuindo valores e bindings
            lblID.Text = Strings.ID;
            lblIDContent.SetBinding(Label.TextProperty, "Id");
            lblUser.Text = Strings.UserID;
            lblUserContent.SetBinding(Label.TextProperty, "User");
            lblType.Text = Strings.Typeof;
            lblTypeContent.SetBinding(Label.TextProperty, "Typeof");
            lblLastEditAt.Text = Strings.Last_Edit_At;
            lblLastEditAtContent.SetBinding(Label.TextProperty, "Last_edit_at");

            //Propriedades de Layout
            mainLayout.BackgroundColor = Color.FromHex("#eee");
            mainLayout.Orientation = StackOrientation.Vertical;
            firstLine.Orientation = StackOrientation.Horizontal;
            secondLine.Orientation = StackOrientation.Horizontal;


            //Adicionando itens aos layouts
            firstLine.Children.Add(lblID);
            firstLine.Children.Add(lblIDContent);   

            firstLine.Children.Add(lblUser);
            firstLine.Children.Add(lblUserContent);

            secondLine.Children.Add(lblType);
            secondLine.Children.Add(lblTypeContent);

            secondLine.Children.Add(lblLastEditAt);
            secondLine.Children.Add(lblLastEditAtContent);

            mainLayout.Children.Add(firstLine);
            mainLayout.Children.Add(secondLine);


            var details = new MenuItem { Text = Strings.Details };
            details.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
            details.Clicked += async (sender, e) =>
            {
                page.ListView_Events_Details(sender,e);
            };

            var showonmap = new MenuItem { Text = Strings.ShowOnMap };
            showonmap.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
            showonmap.Clicked += async (sender, e) => {
                page.ListView_Events_ShowOnMap(sender, e);
            };

            var edit = new MenuItem { Text = Strings.Edit };
            edit.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
            edit.Clicked += async (sender, e) => {
                page.ListView_Events_Edit(sender, e);
            };

            var delete = new MenuItem { Text = Strings.Delete };
            delete.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
            delete.Clicked += async (sender, e) => {
                page.ListView_Events_Delete(sender, e);
            };

            ContextActions.Add(details);
            ContextActions.Add(showonmap);
            ContextActions.Add(edit);
            ContextActions.Add(delete);

            View = mainLayout;
        }
    }
}