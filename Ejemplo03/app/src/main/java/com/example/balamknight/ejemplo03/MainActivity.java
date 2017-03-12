package com.example.balamknight.ejemplo03;

import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.EditText;
import android.widget.TextView;

import com.example.balamknight.ejemplo03.utilities.NetworkUtils;

import java.io.IOException;
import java.net.URL;

public class MainActivity extends AppCompatActivity {

    EditText txtQuery ;
    TextView txtResult;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        txtQuery = (EditText ) findViewById(R.id.txtQuery);
        txtResult = (TextView) findViewById(R.id.txtResultado);


    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {

        getMenuInflater().inflate(R.menu.main,menu);
        return super.onCreateOptionsMenu(menu);
    }

    public class QueryTask extends AsyncTask<URL, Void, String>
    {
        @Override
        protected String doInBackground(URL... params) {
            String resultado="";
            try {
                resultado = NetworkUtils.getResponseFromHttpUrl(params[0]);
            }
            catch (IOException e)
            {
                e.printStackTrace();
            }
            return resultado;
        }

        @Override
        protected void onPostExecute(String s) {
            if (s!= null && !s.equals(""))
                txtResult.setText(s);
            super.onPostExecute(s);
        }
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        int itemID = item.getItemId();
        if (itemID == R.id.btnSearch) {
            String txtPais = txtQuery.getText().toString();
            URL SearchURL = NetworkUtils.buildUrl(txtPais);

            new QueryTask().execute(SearchURL);
        }
        return super.onOptionsItemSelected(item);
    }
}
